using TrackerLibrary.Models;

namespace TrackerLibrary.Connections
{
    public interface IDataConnection
    {
        List<Person> GetAllPersons();
        List<Team> GetAllTeams();
        List<Tournament> GetAllTournaments();
        void CreatePrize(Prize prize);
        void CreatePerson(Person person);
        void CreateTeam(Team team);
        void CreateTournament(Tournament tournament);
        void UpdateMatchup(Matchup matchup);
        void UpdateTeamCompeting(MatchupEntry matchupEntry);
        void CompleteTournament(Tournament tournament);

    }
}
