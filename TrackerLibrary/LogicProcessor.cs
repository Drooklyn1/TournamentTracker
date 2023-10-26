using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class LogicProcessor
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

                        if (GlobalConfig.WinnerDetermination == ScoreType.Lesser)
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

                // update TeamCompeting of MatchupEntry in next round with the Winner

                UpdateNextRound(selectedMatchup, tournament);
            }
            else
            {
                throw new Exception("No matchup selected.");
            }
        }

        private static void UpdateNextRound(Matchup selectedMatchup, Tournament tournament)
        {
            int currentRound = selectedMatchup.Round;

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

                        UpdateNextRound(m, tournament);
                    }
                }
            }
        }

    }
}
