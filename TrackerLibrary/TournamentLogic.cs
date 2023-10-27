using System.Security.Cryptography;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(Tournament newTournament)
        {
            List<Team> randomizedTeams = RandomizeTeams( newTournament.Teams );
            int numberOfRounds = GetNumberOfRounds( randomizedTeams.Count );
            int byes = GetNumberOfByes( randomizedTeams.Count, numberOfRounds );

            newTournament.Rounds.Add( CreateFirstRound( randomizedTeams, byes ) );
            CreateRemainingRounds( newTournament, numberOfRounds );
        }

        private static List<Team> RandomizeTeams(List<Team> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private static int GetNumberOfRounds(int count)
        {
            // Log2(1)=0, Log2(2)=1 , Log2(4)=2 , Log2(8)=3 , Log2(16)=4 , ...

            if (count <= 2) return 1;
            else            return (int) Math.Ceiling( Math.Log2(count) );
        }

        private static int GetNumberOfByes(int count, int rounds)
        {
            return (int) Math.Pow(2, rounds) - count;
        }

        private static List<Matchup> CreateFirstRound(List<Team> teams, int byes)
        {
            List<Matchup> output = new List<Matchup>();
            Matchup currentMatchup = new Matchup();

            foreach (Team team in teams)
            {
                currentMatchup.Entries.Add( new MatchupEntry { TeamCompeting = team } );

                if (byes > 0 || currentMatchup.Entries.Count > 1)
                {
                    currentMatchup.Round = 1;
                    output.Add(currentMatchup);
                    currentMatchup = new Matchup();

                    if (byes > 0) byes -= 1;
                }
            }

            return output;
        }

        private static void CreateRemainingRounds(Tournament newTournament, int rounds)
        {
            int round = 2;
            List<Matchup> previousRound = newTournament.Rounds[0];
            List<Matchup> currentRound = new List<Matchup>();
            Matchup currentMatchup = new Matchup();

            while (round <= rounds)
            {
                foreach (Matchup oldMatchup in previousRound)
                {
                    currentMatchup.Entries.Add( new MatchupEntry { ParentMatchup = oldMatchup } );

                    if (currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.Round = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new Matchup();
                    }
                }

                newTournament.Rounds.Add(currentRound);
                previousRound = currentRound;

                currentRound = new List<Matchup>();
                round++;
            }
        }

        public static void UpdateResult(Matchup selectedMatchup, Tournament tournament)
        {
            if (selectedMatchup != null)
            {
                // If a Team has a Bye, set them as the Winner

                if (selectedMatchup.Entries.Count == 1)
                {
                    if (selectedMatchup.Entries[0].TeamCompeting != null)
                    {
                        selectedMatchup.Winner = selectedMatchup.Entries[0].TeamCompeting;
                    }
                }
                else if (selectedMatchup.Entries.Count == 2)
                {
                    if (selectedMatchup.Entries[0].TeamCompeting != null && selectedMatchup.Entries[1].TeamCompeting != null)
                    {
                        // Determine the Winner of the Matchup

                        if (GlobalConfig.WinnerDetermination() == "Lesser")
                        {
                            if (selectedMatchup.Entries[0].Score < selectedMatchup.Entries[1].Score)
                            {
                                selectedMatchup.Winner = selectedMatchup.Entries[0].TeamCompeting;
                            }
                            else if (selectedMatchup.Entries[1].Score < selectedMatchup.Entries[0].Score)
                            {
                                selectedMatchup.Winner = selectedMatchup.Entries[1].TeamCompeting;
                            }
                            else
                            {
                                throw new Exception("Ties are not allowed in this application.");
                            }
                        }
                        else
                        {
                            if (selectedMatchup.Entries[0].Score > selectedMatchup.Entries[1].Score)
                            {
                                selectedMatchup.Winner = selectedMatchup.Entries[0].TeamCompeting;
                            }
                            else if (selectedMatchup.Entries[1].Score > selectedMatchup.Entries[0].Score)
                            {
                                selectedMatchup.Winner = selectedMatchup.Entries[1].TeamCompeting;
                            }
                            else
                            {
                                throw new Exception("Ties are not allowed in this application.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("At least one of the competing teams is not determined yet.");
                    }
                }
                else
                {
                    throw new Exception("The selected matchup has no valid entries.");
                }

                GlobalConfig.Connection.UpdateMatchup(selectedMatchup);

                // Update TeamCompeting of MatchupEntry in next round with the Winner and reset subsequent rounds

                try
                {
                    UpdateNextRound(selectedMatchup, tournament);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("No matchup selected.");
            }
        }

        private static void UpdateNextRound(Matchup selectedMatchup, Tournament tournament)
        {
            // Get the round we were working on and if there's still matches left to play

            int currentRound = selectedMatchup.Round;
            bool unplayedMatchesInRound = tournament.Rounds[currentRound - 1].Any(x => x.Winner == null);

            // Update the next round MatchupEntry with the Winner as TeamCompeting, if there is another round to play

            if (currentRound < tournament.Rounds.Count)
            {
                foreach (Matchup m in tournament.Rounds[currentRound])
                {
                    List<MatchupEntry> foundEntry = m.Entries.Where(x => x.ParentMatchup.ID == selectedMatchup.ID).ToList();

                    if (foundEntry.Count > 0)
                    {
                        // If current Matchup doesn't have a winner, there's no team competing here

                        if (selectedMatchup.Winner != null)
                        {
                            foundEntry.First().TeamCompeting = selectedMatchup.Winner;
                        }
                        else
                        {
                            foundEntry.First().TeamCompeting = null;
                        }

                        GlobalConfig.Connection.UpdateTeamCompeting(foundEntry.First());

                        // Reset the Winner and scores in case this was processed before

                        m.Winner = null;
                        m.Entries.ForEach(x => x.Score = 0);

                        GlobalConfig.Connection.UpdateMatchup(m);

                        // Run it again for the next round after this, so the relevant result is also reset

                        try
                        {
                            UpdateNextRound(m, tournament);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    // If all matches were played in the round of "selectedMatchup", notify each user in the next round

                    if (!unplayedMatchesInRound)
                    {
                        try
                        { 
                            NewRoundAlert(m);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }

            // If there's no more round AND no more match to play then tournament is complete

            else
            {
                if ( !unplayedMatchesInRound )
                {
                    try
                    { 
                        TournamentFinishedAlert(tournament);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private static void NewRoundAlert(Matchup m)
        {
            // Notify all Persons in the next round by Email

            foreach (MatchupEntry e in m.Entries)
            {
                if (e.TeamCompeting != null)
                {
                    foreach (Person p in e.TeamCompeting.TeamMembers)
                    {
                        string opponent = "";
                        MatchupEntry oppEntry = m.Entries.Where(x => x.TeamCompeting != e.TeamCompeting).FirstOrDefault();

                        if (oppEntry != null) opponent = oppEntry.DisplayName;

                        try
                        {
                            EmailLogic.EmailUserNewRound(p, e.TeamCompeting.TeamName, opponent);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
        }

        private static void TournamentFinishedAlert(Tournament tournament)
        {
            // Notify all Participants (Persons from the first round matchups)

            foreach (Matchup m in tournament.Rounds[0])
            {
                foreach (MatchupEntry e in m.Entries)
                {
                    if (e.TeamCompeting != null)
                    {
                        foreach (Person p in e.TeamCompeting.TeamMembers)
                        {
                            string winner = tournament.Rounds[tournament.Rounds.Count - 1].FirstOrDefault().Winner.TeamName;

                            try
                            {
                                EmailLogic.EmailUserTournamentFinished(p, e.TeamCompeting.TeamName, winner);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        public static void FirstRoundAlert(Tournament tournament)
        {
            // Notify all Persons in the first round after Tournament is created

            foreach (Matchup m in tournament.Rounds[0])
            {
                try
                { 
                    NewRoundAlert(m);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
