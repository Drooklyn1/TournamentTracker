using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntry
    {
        /// <summary>
        /// Unique ID of the Matchup Entry
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Represents the Team ID from the database to look up the TeamCompeting
        /// </summary>
        public int TeamCompetingID { get; set; }

        /// <summary>
        /// Represents one Team in the matchup
        /// </summary>
        public Team TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score for this team
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Represents the Matchup ID from the database to look up the ParentMatchup
        /// </summary>
        public int ParentMatchupID { get; set; }

        /// <summary>
        /// Represents the matchup that this team came from as the winner
        /// </summary>
        public Matchup ParentMatchup { get; set; }

        public MatchupEntry()
        {

        }

    }
}
