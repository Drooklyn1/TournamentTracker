using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Tournament
    {
        /// <summary>
        /// Unique ID of the Tournament
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the Tournament
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Entry Fee for the Tournament
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// List of registered Teams for the Tournament
        /// </summary>
        public List<Team> Teams { get; set; } = new List<Team>();

        /// <summary>
        /// List of Prizes created for the Tournament
        /// </summary>
        public List<Prize> Prizes { get; set; } = new List<Prize>();

        /// <summary>
        /// List of Matchups in the Tournament
        /// </summary>
        public List<List<Matchup>> Rounds { get; set; } = new List<List<Matchup>>();

        public Tournament()
        {

        }

        public Tournament(string tournamentName, decimal entryFee, List<Team> teams, List<Prize> prizes)
        {
            TournamentName = tournamentName;
            EntryFee = entryFee;
            Teams = teams;
            Prizes = prizes;
        }

    }
}
