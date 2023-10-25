using System.Configuration;
using TrackerLibrary.Models;

namespace TrackerLibrary.Connections.FileProcesses
{
    public static class FileProcessor
    {
        // Extension methods for certain var types due to "this" and seprate namespace so var types don't have it outside of it

        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static void WriteFile(this string file, List<string> lines)
        {
            File.WriteAllLines(file, lines);
        }

        // Converters

        public static List<Prize> ConvertToPrizes(this List<string> lines)
        {
            List<Prize> output = new List<Prize>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Prize p = new Prize();
                p.ID = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);

                output.Add(p);
            }

            return output;
        }

        public static List<Person> ConvertToPersons(this List<string> lines)
        {
            List<Person> output = new List<Person>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Person p = new Person();
                p.ID = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.Email = cols[3];
                p.Cellphone = cols[4];

                output.Add(p);
            }

            return output;
        }

        public static List<Team> ConvertToTeams(this List<string> lines)
        {
            // id,TeamName,id|id|id

            List<Team> output = new List<Team>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Team t = new Team();
                t.ID = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIDs = cols[2].Split('|');

                foreach (string id in personIDs)
                {
                    if (id != "") t.TeamMembers.Add(GetPersonByID(int.Parse(id)));
                }

                output.Add(t);
            }

            return output;
        }

        public static List<Tournament> ConvertToTournaments(this List<string> lines)
        {
            // id,TournamentName,EntryFee,( Teams: id|id|id ),( PrizeIDs: id|id ),( Rounds: id*id*id*id|id*id|id )

            List<Tournament> output = new List<Tournament>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Tournament t = new Tournament();
                t.ID = int.Parse(cols[0]);
                t.TournamentName = cols[1];
                t.EntryFee = decimal.Parse(cols[2]);

                string[] teamIDs = cols[3].Split('|');

                foreach (string id in teamIDs)
                {
                    if (id != "") t.Teams.Add(GetTeamByID(int.Parse(id)));
                }

                string[] prizeIDs = cols[4].Split('|');

                foreach (string id in prizeIDs)
                {
                    if(id != "") t.Prizes.Add(GetPrizeByID(int.Parse(id)));
                }

                string[] tournamentRounds = cols[5].Split('|');

                foreach (string roundMatchups in tournamentRounds)
                {
                    List<Matchup> roundList = new List<Matchup>();
                    string[] matchupIDs = roundMatchups.Split("*");

                    foreach (string id in matchupIDs)
                    {
                        if (id != "") roundList.Add(GetMatchupByID(int.Parse(id)));
                    }

                    t.Rounds.Add(roundList);
                }

                output.Add(t);
            }

            return output;
        }

        public static List<Matchup> ConvertToMatchups(this List<string> lines)
        {
            List<Matchup> output = new List<Matchup>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                Matchup m = new Matchup();
                m.ID = int.Parse(cols[0]);
                m.Round = int.Parse(cols[1]);

                if (cols[2] != "") m.Winner = GetTeamByID(int.Parse(cols[2]));

                string[] matchupEntryIDs = cols[3].Split('|');

                List<MatchupEntry> me = new List<MatchupEntry>();

                foreach (string id in matchupEntryIDs)
                {
                    if (id != "") me.Add(GetMatchupEntryByID(int.Parse(id)));
                }

                m.Entries = me;

                output.Add(m);
            }

            return output;
        }

        public static List<MatchupEntry> ConvertToMatchupEntries(this List<string> lines)
        {
            List<MatchupEntry> output = new List<MatchupEntry>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupEntry me = new MatchupEntry();
                me.ID = int.Parse(cols[0]);

                if (cols[1] != "") me.TeamCompeting = GetTeamByID(int.Parse(cols[1]));

                if (cols[2] != "") me.Score = double.Parse(cols[2]);

                if (cols[3] != "") me.ParentMatchup = GetMatchupByID(int.Parse(cols[3]));

                output.Add(me);
            }

            return output;
        }

        public static void PopulateParentIDs(List<string> matchupEntriesData, List<Tournament> tournaments)
        {
            foreach (string matchupEntryString in matchupEntriesData)
            {
                // Matchup Entry we're working on
                int matchupEntryID = int.Parse(matchupEntryString.Split(',')[0]);

                // Parent Matchup we're looking for
                string parentString = matchupEntryString.Split(',')[3];

                // Parent Matchup object we need to save into the Matchup Entry
                Matchup parentMatchup = null;

                if (parentString != "")
                {
                    int parentMatchupID = int.Parse(parentString);

                    foreach (Tournament tournament in tournaments)
                    {
                        foreach (List<Matchup> round in tournament.Rounds)
                        {
                            // If: Parent Matchup was already found, save it into the Matchup Entry we're working on

                            if (parentMatchup != null)
                            {
                                foreach (Matchup matchup in round)
                                {
                                    List<MatchupEntry> foundMatchupEntry = matchup.Entries.Where(x => x.ID == matchupEntryID).ToList();
                                    if (foundMatchupEntry.Count > 0)
                                    {
                                        matchup.Entries.Where(x => x.ID == matchupEntryID).First().ParentMatchup = parentMatchup;
                                        break;
                                    }
                                }
                            }

                            // Else: Search the round for the Parent Matchup and save the object if found

                            else
                            {
                                List<Matchup> foundParentMatchup = round.Where(x => x.ID == parentMatchupID).ToList();

                                if (foundParentMatchup.Count > 0)
                                {
                                    parentMatchup = foundParentMatchup.First();
                                }
                            }
                            
                        }

                        if (parentMatchup != null) break;
                    }
                }
            }
        }

        // Savers

        public static void SavePrizes(this string file, List<string> prizesData, Prize newPrize)
        {
            // Construct String for the new Prize

            string s = NewPrizeString(newPrize);

            // Add new Prize String to List<string> with all prizes

            prizesData.Add(s);

            // Create or Overwrite the file

            file.WriteFile(prizesData);
        }

        public static string NewPrizeString(Prize newPrize)
        {
            return $"{newPrize.ID},{newPrize.PlaceNumber},{newPrize.PlaceName},{newPrize.PrizeAmount},{newPrize.PrizePercentage}";
        }
        
        public static void SavePersons(this string file, List<string> personsData, Person newPerson)
        {
            // Construct String for the new Person

            string s = NewPersonString(newPerson);

            // Add new Person String to List<string> with all persons

            personsData.Add(s);

            // Create or Overwrite the file

            file.WriteFile(personsData);
        }

        public static string NewPersonString(Person newPerson)
        {
            return $"{newPerson.ID},{newPerson.FirstName},{newPerson.LastName},{newPerson.Email},{newPerson.Cellphone}";
        }

        public static void SaveTeams(this string file, List<string> teamsData, Team newTeam)
        {
            // Construct String for the new Team

            string s = NewTeamString(newTeam);

            // Add new Team String to List<string> with all teams

            teamsData.Add(s);

            // Create or Overwrite the file

            file.WriteFile(teamsData);
        }

        public static string NewTeamString(Team newTeam)
        {
            // id,TeamName,id|id|id

            string newTeamString = $"{newTeam.ID},{newTeam.TeamName},";

            foreach (Person tm in newTeam.TeamMembers)
            {
                newTeamString += $"{tm.ID}|";
            }

            newTeamString = newTeamString.Substring(0, newTeamString.Length - 1);

            return newTeamString;
        }

        public static void SaveTournaments(this string file, List<string> tournamentsData, Tournament newTournament)
        {
            
            // Construct String for the new Tournament

            string s = NewTournamentString(newTournament);

            // Add new Tournament String to List<string> with all tournaments

            tournamentsData.Add(s);

            // Create or Overwrite the file

            file.WriteFile(tournamentsData);
        }

        public static string NewTournamentString(Tournament newTournament)
        {
            // id,TournamentName,EntryFee,( Teams: id|id|id ),( PrizeIDs: id|id ),( Rounds: id*id*id*id|id*id|id )

            string newTournamentString = $"{newTournament.ID},{newTournament.TournamentName},{newTournament.EntryFee},";

            foreach (Team team in newTournament.Teams)
            {
                newTournamentString += $"{team.ID}|";
            }

            if (newTournament.Teams.Count > 0) newTournamentString = newTournamentString.Substring(0, newTournamentString.Length - 1);

            newTournamentString += ",";

            foreach (Prize prize in newTournament.Prizes)
            {
                newTournamentString += $"{prize.ID}|";
            }

            if (newTournament.Prizes.Count > 0) newTournamentString = newTournamentString.Substring(0, newTournamentString.Length - 1);

            newTournamentString += ",";

            foreach (List<Matchup> roundMatchups in newTournament.Rounds)
            {
                foreach (Matchup matchup in roundMatchups)
                {
                    newTournamentString += $"{matchup.ID}*";
                }

                if (roundMatchups.Count > 0)
                {
                    newTournamentString = newTournamentString.Substring(0, newTournamentString.Length - 1);
                }

                newTournamentString += "|";
            }

            if (newTournament.Rounds.Count > 0) newTournamentString = newTournamentString.Substring(0, newTournamentString.Length - 1);

            return newTournamentString;
        }

        public static void SaveMatchups(List<string> matchupsData, List<string> matchupEntriesData, Tournament newTournament)
        {
            // Determine new IDs for Matchups and Matchup Entries

            int currentMatchupID = 1;
            if (matchupsData.Count >= 1)
            {
                currentMatchupID = int.Parse(matchupsData.Last().Split(',')[0]) + 1;
            }

            int currentMatchupEntryID = 1;
            if (matchupEntriesData.Count >= 1)
            {
                currentMatchupEntryID = int.Parse(matchupEntriesData.Last().Split(',')[0]) + 1;
            }

            // Construct String for the each matchup in the tournament and for each entry per matchup

            string matchupString;

            foreach (List<Matchup> round in newTournament.Rounds)
            {
                foreach(Matchup matchup in round)
                {
                    matchup.ID = currentMatchupID;

                    matchupString = NewMatchupString(matchup);

                    foreach (MatchupEntry entry in matchup.Entries)
                    {
                        entry.ID = currentMatchupEntryID;

                        matchupString += $"{ entry.ID }|";

                        // Add current MatchupEntry String to List<MatchupEntry> with all matchup entries

                        matchupEntriesData.Add( NewMatchupEntryString(entry) );

                        currentMatchupEntryID++;
                    }

                    if (matchup.Entries.Count > 0) matchupString = matchupString.Substring(0, matchupString.Length - 1);

                    // Add current Matchup String to List<string> with all matchups

                    matchupsData.Add(matchupString);

                    currentMatchupID++;
                }
            }

            // Create or Overwrite the files
            
            GlobalConfig.MatchupsFile.FullFilePath().WriteFile(matchupsData);

            GlobalConfig.MatchupEntriesFile.FullFilePath().WriteFile(matchupEntriesData);
        }

        private static string NewMatchupString(Matchup matchup)
        {
            // id,Round,Winner,( MatchupEntries: id|id )

            string winner;

            if (matchup.Winner == null) winner = "";
            else                        winner = matchup.Winner.ID.ToString();

            return $"{ matchup.ID },{ matchup.Round },{ winner },";
        }

        private static string NewMatchupEntryString(MatchupEntry entry)
        {
            // id,Team,Score,Parent

            string team, parent;

            if (entry.TeamCompeting == null) team = "";
            else                             team = entry.TeamCompeting.ID.ToString();
            if (entry.ParentMatchup == null) parent = "";
            else                             parent = entry.ParentMatchup.ID.ToString();

            return $"{ entry.ID },{ team },{ entry.Score },{ parent }";
        }

        // Getters

        private static Prize GetPrizeByID(int id)
        {
            List<string> prizes = GlobalConfig.PersonsFile.FullFilePath().LoadFile();
            List<string> foundPrizes = new List<string>();

            foreach (string prize in prizes)
            {
                string[] cols = prize.Split(',');

                if (id == int.Parse(cols[0]))
                {
                    foundPrizes.Add(prize);
                    return foundPrizes.ConvertToPrizes().First();
                }
            }

            return null;

            //List<Prize> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizes();
            //return prizes.Where(x => x.ID == id).First();
        }

        private static Person GetPersonByID(int id)
        {
            List<string> persons = GlobalConfig.PersonsFile.FullFilePath().LoadFile();
            List<string> foundPersons = new List<string>();

            foreach (string person in persons)
            {
                string[] cols = person.Split(',');

                if (id == int.Parse(cols[0]))
                {
                    foundPersons.Add(person);
                    return foundPersons.ConvertToPersons().First();
                }
            }

            return null;

            //List<Person> persons = GlobalConfig.PersonsFile.FullFilePath().LoadFile().ConvertToPersons();
            //return persons.Where(x => x.ID == id).First();
        }

        private static Team GetTeamByID(int id)
        {
            List<string> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile();
            List<string> foundTeams = new List<string>();

            foreach (string team in teams)
            {
                string[] cols = team.Split(',');

                if (id == int.Parse(cols[0]))
                {
                    foundTeams.Add(team);
                    return foundTeams.ConvertToTeams().First();
                }
            }

            return null;

            //List<Team> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile().ConvertToTeams();
            //return teams.Where(x => x.ID == id).First();
        }

        private static Matchup GetMatchupByID(int id)
        {
            List<string> matchups = GlobalConfig.MatchupsFile.FullFilePath().LoadFile();
            List<string> foundMatchups = new List<string>();

            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');

                if (id == int.Parse(cols[0]))
                {
                    foundMatchups.Add(matchup);
                    return foundMatchups.ConvertToMatchups().First();
                }
            }

            return null;

            //List<Matchup> matchups = GlobalConfig.MatchupsFile.FullFilePath().LoadFile().ConvertToMatchups();
            //return matchups.Where(x => x.ID == id).First();
        }

        private static MatchupEntry GetMatchupEntryByID(int id)
        {
            List<string> matchupEntries = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile();
            List<string> foundEntries = new List<string>();

            foreach (string matchupEntry in matchupEntries)
            {
                string[] cols = matchupEntry.Split(',');

                if(id == int.Parse(cols[0]))
                {
                    foundEntries.Add(matchupEntry);
                    return foundEntries.ConvertToMatchupEntries().First();
                }
            }

            return null;

            //List<MatchupEntry> matchupEntries = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile().ConvertToMatchupEntries();
            //return matchupEntries.Where(x => x.ID == id).First();
        }

    }
}