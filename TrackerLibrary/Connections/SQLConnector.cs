﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrackerLibrary.Models;

//   @PlaceNumber int
//   @PlaceName nvarchar(50)
//   @PrizeAmount money
//   @PrizePercentage float
//   @id int = 0 output

namespace TrackerLibrary.Connections
{
    public class SQLConnector : IDataConnection
    {
        private const string db = "Tournaments";

        /// <summary>
        /// Saves a new prize to the database
        /// </summary>
        /// <param name="newPrize"></param>
        /// <returns>Prize details with unique identifier</returns>
        public Prize CreatePrize(Prize newPrize)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@PlaceNumber", newPrize.PlaceNumber);
                p.Add("@PlaceName", newPrize.PlaceName);
                p.Add("@PrizeAmount", newPrize.PrizeAmount);
                p.Add("@PrizePercentage", newPrize.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                newPrize.ID = p.Get<int>("@id");
            }

            return newPrize;
        }

        /// <summary>
        /// Saves a new person to the database
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns>Person details with unique identifier</returns>
        public Person CreatePerson(Person newPerson)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@FirstName", newPerson.FirstName);
                p.Add("@LastName", newPerson.LastName);
                p.Add("@Email", newPerson.Email);
                p.Add("@Cellphone", newPerson.Cellphone);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("dbo.spPersons_Insert", p, commandType: CommandType.StoredProcedure);

                newPerson.ID = p.Get<int>("@id");
            }

            return newPerson;
        }

        /// <summary>
        /// Saves a new team to the database
        /// </summary>
        /// <param name="newTeam"></param>
        /// <returns>Team details with unique identifier</returns>
        public Team CreateTeam(Team newTeam)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@TeamName", newTeam.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                newTeam.ID = p.Get<int>("@id");

                foreach (Person tm in newTeam.TeamMembers)
                {
                    p = new DynamicParameters();

                    p.Add("@TeamID", newTeam.ID);
                    p.Add("@PersonID", tm.ID);

                    dbConnection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }
            }

            return newTeam;
        }

        /// <summary>
        /// Saves a new tournament to the database
        /// </summary>
        /// <param name="newTournament"></param>
        /// <returns>Team details with unique identifier</returns>
        public Tournament CreateTournament(Tournament newTournament)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                SaveNewTournament(dbConnection, newTournament);

                SaveTournamentPrizes(dbConnection, newTournament);

                SaveTournamentTeams(dbConnection, newTournament);

                SaveTournamentRounds(dbConnection, newTournament);
            }

            return newTournament;
        }

        private void SaveNewTournament(IDbConnection dbConnection, Tournament newTournament)
        {
            var p = new DynamicParameters();

            p.Add("@TournamentName", newTournament.TournamentName);
            p.Add("@EntryFee", newTournament.EntryFee);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            dbConnection.Execute("dbo.spTournaments_Insert", p, commandType: CommandType.StoredProcedure);

            newTournament.ID = p.Get<int>("@id");
        }

        private void SaveTournamentPrizes(IDbConnection dbConnection, Tournament newTournament)
        {
            foreach (Prize prize in newTournament.Prizes)
            {
                var p = new DynamicParameters();

                p.Add("@TournamentID", newTournament.ID);
                p.Add("@PrizeID", prize.ID);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("dbo.spTournamentPrizes_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentTeams(IDbConnection dbConnection, Tournament newTournament)
        {
            foreach (Team team in newTournament.Teams)
            {
                var p = new DynamicParameters();

                p.Add("@TournamentID", newTournament.ID);
                p.Add("@TeamID", team.ID);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("dbo.spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentRounds(IDbConnection dbConnection, Tournament newTournament)
        {
            foreach (List<Matchup> round in newTournament.Rounds)
            {
                foreach (Matchup matchup in round)
                {
                    var p = new DynamicParameters();

                    p.Add("@TournamentID", newTournament.ID);
                    p.Add("@Round", matchup.Round);
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    dbConnection.Execute("dbo.spMatchups_Insert", p, commandType: CommandType.StoredProcedure);

                    matchup.ID = p.Get<int>("@id");

                    foreach (MatchupEntry entry in matchup.Entries)
                    {
                        p = new DynamicParameters();

                        p.Add("@MatchupID", matchup.ID);

                        if (entry.ParentMatchup == null) p.Add("@ParentMatchupID", null);
                        else                             p.Add("@ParentMatchupID", entry.ParentMatchup.ID);

                        if (entry.TeamCompeting == null) p.Add("@TeamID", null);
                        else                             p.Add("@TeamID", entry.TeamCompeting.ID);

                        p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        dbConnection.Execute("dbo.spMatchupEntries_Insert", p, commandType: CommandType.StoredProcedure);

                        entry.ID = p.Get<int>("@id");
                    }
                }
            }
        }

        /// <summary>
        /// Get all Person entries from the database
        /// </summary>
        /// <returns>All available Persons</returns>
        public List<Person> GetAllPersons()
        {
            List<Person> allPersons;

            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                allPersons = dbConnection.Query<Person>("dbo.spPersons_GetAll").ToList();
            }

            return allPersons;
        }

        /// <summary>
        /// Get all Team entries from the database
        /// </summary>
        /// <returns>All available Teams</returns>
        public List<Team> GetAllTeams()
        {
            List<Team> allTeams;

            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                allTeams = dbConnection.Query<Team>("dbo.spTeams_GetAll").ToList();

                foreach (Team t in allTeams)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamID", t.ID);

                    t.TeamMembers = dbConnection.Query<Person>("dbo.spPersons_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return allTeams;
        }

        /// <summary>
        /// Get all Tournament entries from the database
        /// </summary>
        /// <returns>All available Tournaments</returns>
        public List<Tournament> GetAllTournaments()
        {
            List<Tournament> allTournaments;

            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                allTournaments = dbConnection.Query<Tournament>("dbo.spTournaments_GetAll").ToList();

                foreach (Tournament t in allTournaments)
                {
                    var p = new DynamicParameters();
                    var p2 = new DynamicParameters();
                    p.Add("@TournamentID", t.ID);

                    // Populate Prizes
                    t.Prizes = dbConnection.Query<Prize>("dbo.spPrizes_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    // Populate Teams
                    t.Teams = dbConnection.Query<Team>("dbo.spTeams_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();
                    
                    foreach (Team team in t.Teams)
                    {
                        p2 = new DynamicParameters();
                        p2.Add("@TeamID", t.ID);

                        team.TeamMembers = dbConnection.Query<Person>("dbo.spPersons_GetByTeam", p2, commandType: CommandType.StoredProcedure).ToList();
                    }

                    // Populate Rounds
                    List<Matchup> matchups = dbConnection.Query<Matchup>("dbo.spMatchups_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (Matchup matchup in matchups)
                    {
                        p2 = new DynamicParameters();
                        p2.Add("@MatchupID", matchup.ID);

                        matchup.Entries = dbConnection.Query<MatchupEntry>("dbo.spMatchupEntries_GetByMatchup", p2, commandType: CommandType.StoredProcedure).ToList();

                        List<Team> allTeams = GetAllTeams();

                        if (matchup.WinnerID > 0)
                        {
                            matchup.Winner = allTeams.Where(x => x.ID == matchup.WinnerID).First();
                        }

                        foreach (MatchupEntry entry in matchup.Entries)
                        {
                            if (entry.TeamCompetingID > 0)
                            {
                                entry.TeamCompeting = allTeams.Where(x => x.ID == entry.TeamCompetingID).First();
                            }

                            if (entry.ParentMatchupID > 0)
                            {
                                entry.ParentMatchup = matchups.Where(x => x.ID == entry.ParentMatchupID).First();
                            }
                        }
                    }

                    // List< List< Matchup > >
                    List<Matchup> roundList = new List<Matchup>();
                    int currentRound = 1;

                    foreach (Matchup matchup in matchups)
                    {
                        if (matchup.Round > currentRound)
                        {
                            t.Rounds.Add(roundList);
                            roundList = new List<Matchup>();
                            currentRound++;
                        }

                        roundList.Add(matchup);
                    }

                    t.Rounds.Add(roundList);
                }
            }

            return allTournaments;
        }

    }
}
