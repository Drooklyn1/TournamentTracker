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
            GlobalConfig.InitializeWinnerDetermination();

            // Initialize User's Email-address, where Emails are sent from
            GlobalConfig.InitializeUser();

            Application.Run(new TournamentDashboard());
        }
    }
}