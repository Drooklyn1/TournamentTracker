using System.Configuration;
using TrackerLibrary.Connections;
using TrackerLibrary.Models;

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
        public static EmailConfig EmailConfig { get; private set; } = new EmailConfig();

        public static void InitializeConnections()
        {
            string dbType = ConfigurationManager.AppSettings["dataStorage"];
            switch (dbType)
            {
                case "SQL":
                    Connection = new SQLConnector();
                    break;
                case "FILES":
                    Connection = new FileConnector();
                    break;
                default:
                    break;
            }
        }

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

        public static string ConnectionString(string dbName)
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

        public static void UpdateEmailConfig(string userName, string userEmail, string userPassword, string userHost, int userPort)
        {
            EmailConfig.UserName = userName;
            EmailConfig.UserEmail = userEmail;
            EmailConfig.UserPassword = userPassword;
            EmailConfig.UserHost = userHost;
            EmailConfig.UserPort = userPort;
        }

    }
}
