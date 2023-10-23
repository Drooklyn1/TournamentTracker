using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.Connections
{
    public interface IDataConnection
    {
        List<Person> GetAllPersons();
        List<Team> GetAllTeams();
        List<Tournament> GetAllTournaments();
        Prize CreatePrize(Prize prize);
        Person CreatePerson(Person person);
        Team CreateTeam(Team team);
        Tournament CreateTournament(Tournament tournament);

    }
}
