using TrackerLibrary;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialize the Database Connections
            GlobalConfig.InitializeConnections(DatabaseType.FILES);

            // Initialize the Score Type for the Winner determination
            GlobalConfig.InitializeWinnerDetermination(ScoreType.Greater);

            Application.Run(new TournamentDashboard());
            //Application.Run(new TournamentViewer());
            //Application.Run(new TournamentCreator());
            //Application.Run(new TeamCreator());
            //Application.Run(new PrizeCreator());
        }
    }
}