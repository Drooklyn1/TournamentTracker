using System.Configuration;
using TrackerLibrary.Connections;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizesFile = "PrizesFile.csv";
        public const string PersonsFile = "PersonsFile.csv";
        public const string TeamsFile = "TeamsFile.csv";
        public const string TournamentsFile = "TournamentsFile.csv";
        public const string MatchupsFile = "MatchupsFile.csv";
        public const string MatchupEntriesFile = "MatchupEntriesFile.csv";

        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.SQL:
                    Connection = new SQLConnector();
                    break;
                case DatabaseType.FILES:
                    Connection = new FileConnector();
                    break;
                default:
                    break;
            }
        }

        public static string WinnerDetermination()
        {
            return ConfigurationManager.AppSettings["winnerDetermination"];
        }

        public static string UserEmail()
        {
            return ConfigurationManager.AppSettings["userEmail"];
        }

        public static string UserName()
        {
            return ConfigurationManager.AppSettings["userName"];
        }

        public static string ConnectionString(string dbName)
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

    }
}
