using System.Net;
using System.Net.Mail;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void EmailUserNewRound(Person p, string teamName, string opponent)
        {
            if (p.Email.Length == 0)
            {
                return;
            }

            List<string> to = new List<string>();
            string subject;
            StringBuilder body = new StringBuilder();

            to.Add(p.Email);

            if (opponent != "")
            {
                subject = $"Your team {teamName} has a new matchup with {opponent}";

                body.AppendLine($"<h1>Your Team {teamName} has a new matchup</h1>\n");
                body.AppendLine("\n");
                body.Append($"<strong>Opponent: </strong>");
                body.AppendLine(opponent + "\n");
                body.AppendLine("\n");
                body.AppendLine("\n");
                body.AppendLine("Good luck!\n");
                body.AppendLine("\n");
                body.AppendLine("~TournamentTracker");
            }
            else
            {
                subject = $"Your team {teamName} has a bye this round.";

                body.AppendLine($"<h1>Your Team {teamName} has a bye this round</h1>\n");
                body.AppendLine("\n");
                body.AppendLine("\n");
                body.AppendLine("Enjoy the week off!\n");
                body.AppendLine("\n");
                body.AppendLine("~TournamentTracker");
            }

            SendEmail(to, subject, body.ToString());
        }

        public static void SendEmail(List<string> to, string subject, string body) 
        {
            MailMessage message = new MailMessage();

            MailAddress fromAddress = new MailAddress(GlobalConfig.UserEmail(), GlobalConfig.FromName());

            to.ForEach( toEmail => message.To.Add(toEmail) );

            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = GlobalConfig.EmailHost();
            smtpClient.Port = GlobalConfig.EmailPort();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(GlobalConfig.UserEmail(), GlobalConfig.AppKey());
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Send(message);
        }

    }
}
