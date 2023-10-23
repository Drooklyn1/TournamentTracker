using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Team
    {
        /// <summary>
        /// Unique ID of the Team
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// List of Persons in the Team
        /// </summary>
        public List<Person> TeamMembers { get; set; } = new List<Person>();

        /// <summary>
        /// Name of the Team
        /// </summary>
        public string TeamName { get; set; }

        public Team()
        {

        }

        public Team(string teamName, List<Person> teamMembers)
        {
            TeamName = teamName;
            TeamMembers = teamMembers;
        }

    }
}
