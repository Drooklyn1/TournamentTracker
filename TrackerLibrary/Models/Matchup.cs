using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Matchup
    {
        /// <summary>
        /// Unique ID of the Matchup
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Represents the round in the tournament of the matchup
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// Represents the Team ID from the database to look up the Winner
        /// </summary>
        public int WinnerID { get; set; }

        /// <summary>
        /// Represents the team that won the matchup
        /// </summary>
        public Team Winner { get; set; }

        /// <summary>
        /// Represents a list of teams with their score for a matchup
        /// </summary>
        public List<MatchupEntry> Entries { get; set; } = new List<MatchupEntry>();

        /// <summary>
        /// Generates a string to display for the matchup
        /// </summary>
        public string DisplayName 
        { 
            get
            {
                string s = $"{ID}: ";

                foreach (MatchupEntry me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        s += $"{me.TeamCompeting.TeamName}";

                        if (Entries.Count == 1) s += " -> has a bye";
                        else if (me == Entries[0]) s += " -vs- ";
                    }
                    else if (me.ParentMatchup != null)
                    {
                        s += $"Winner of {me.ParentMatchup.ID}";
                        if (me == Entries[0]) s += " -vs- ";
                    }
                }

                return s;
            }
        }


        public Matchup()
        {

        }

    }
}
