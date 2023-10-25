using TrackerLibrary.Models;

namespace TrackerUI.Interfaces
{
    public interface ITournamentRequestor
    {
        public void TournamentCompleted(Tournament tournament);
    }
}
