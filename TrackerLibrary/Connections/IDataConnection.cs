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
        void UpdateMatchup(Matchup matchup);
        void UpdateMatchupEntry(MatchupEntry matchupEntry);

    }
}
