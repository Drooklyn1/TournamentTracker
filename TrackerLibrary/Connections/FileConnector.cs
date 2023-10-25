using TrackerLibrary.Models;
using TrackerLibrary.Connections.FileProcesses;
using System.Text.RegularExpressions;

namespace TrackerLibrary.Connections
{
    public class FileConnector : IDataConnection
    {
        /// <summary>
        /// Get all Person entries from a text file
        /// </summary>
        /// <returns>All available Persons</returns>
        public List<Person> GetAllPersons()
        {
            List<Person> allPersons = GlobalConfig.PersonsFile.FullFilePath().LoadFile().ConvertToPersons();

            return allPersons;
        }

        /// <summary>
        /// Get all Team entries from a text file
        /// </summary>
        /// <returns>All available Teams</returns>
        public List<Team> GetAllTeams()
        {
            List<Team> allTeams = GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeams();

            return allTeams;
        }

        /// <summary>
        /// Get all Tournament entries from a text file
        /// </summary>
        /// <returns>All available Tournaments</returns>
        public List<Tournament> GetAllTournaments()
        {
            List<Tournament> allTournaments = GlobalConfig.TournamentsFile.FullFilePath().LoadFile().ConvertToTournaments();

            return allTournaments;
        }

        /// <summary>
        /// Saves a new prize to a text file
        /// </summary>
        /// <param name="newPrize"></param>
        /// <returns>Prize details with unique identifier</returns>
        public Prize CreatePrize(Prize newPrize)
        {
            List<string> prizesData = GlobalConfig.PrizesFile.FullFilePath().LoadFile();
            List<Prize> prizes = prizesData.ConvertToPrizes();

            int currentID = 1;
            if (prizes.Count >= 1)
            {
                currentID = prizes.OrderByDescending(x => x.ID).First().ID + 1;
            }

            newPrize.ID = currentID;

            prizes.Add(newPrize);

            GlobalConfig.PrizesFile.FullFilePath().SavePrizes(prizesData, newPrize);

            return newPrize;
        }

        /// <summary>
        /// Saves a new person to a text file
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns>Person details with unique identifier</returns>
        public Person CreatePerson(Person newPerson)
        {
            List<string> personsData = GlobalConfig.PersonsFile.FullFilePath().LoadFile();
            List<Person> persons = personsData.ConvertToPersons();

            int currentID = 1;
            if (persons.Count >= 1)
            {
                currentID = persons.OrderByDescending(x => x.ID).First().ID + 1;
            }

            newPerson.ID = currentID;

            persons.Add(newPerson);

            GlobalConfig.PersonsFile.FullFilePath().SavePersons(personsData, newPerson);

            return newPerson;
        }

        /// <summary>
        /// Saves a new team to a text file
        /// </summary>
        /// <param name="newTeam"></param>
        /// <returns>Team details with unique identifier</returns>
        public Team CreateTeam(Team newTeam)
        {
            List<string> teamsData = GlobalConfig.TeamsFile.FullFilePath().LoadFile();
            List<Team> teams = teamsData.ConvertToTeams();

            int currentID = 1;
            if (teams.Count >= 1)
            {
                currentID = teams.OrderByDescending(x => x.ID).First().ID + 1;
            }

            newTeam.ID = currentID;

            teams.Add(newTeam);

            GlobalConfig.TeamsFile.FullFilePath().SaveTeams(teamsData, newTeam);

            return newTeam;
        }

        /// <summary>
        /// Saves a new tournament to a text file
        /// </summary>
        /// <param name="newTournament"></param>
        /// <returns>Tournament details with unique identifier</returns>
        public Tournament CreateTournament(Tournament newTournament)
        {
            List<string> matchupsData = GlobalConfig.MatchupsFile.FullFilePath().LoadFile();
            List<string> matchupEntriesData = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile();
            List<string> tournamentsData = GlobalConfig.TournamentsFile.FullFilePath().LoadFile();

            List<Tournament> tournaments = tournamentsData.ConvertToTournaments();

            // Alternate Method to populate all MatchupEntries in tournaments with ParentID after conversion
            //FileProcessor.PopulateParentIDs(matchupEntriesData, tournaments);

            int currentID = 1;
            if (tournaments.Count >= 1)
            {
                currentID = tournaments.OrderByDescending(x => x.ID).First().ID + 1;
            }

            newTournament.ID = currentID;

            tournaments.Add(newTournament);

            FileProcessor.SaveMatchups(matchupsData, matchupEntriesData, newTournament);

            GlobalConfig.TournamentsFile.FullFilePath().SaveTournaments(tournamentsData, newTournament);

            return newTournament;
        }

        public void UpdateMatchup(Matchup matchup)
        {
            List<string> matchupsData = GlobalConfig.MatchupsFile.FullFilePath().LoadFile();
            List<string> matchupEntriesData = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile();

            if (matchup.Winner != null && matchup.Entries.Count > 0)
            {
                FileProcessor.UpdateMatchup(matchupsData, matchupEntriesData, matchup);
            }
        }

        public void UpdateMatchupEntry(MatchupEntry matchupEntry)
        {
            List<string> matchupEntriesData = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile();

            if (matchupEntry.TeamCompeting != null)
            {
                FileProcessor.UpdateMatchupEntry(matchupEntriesData, matchupEntry);
            }
        }
    }
}