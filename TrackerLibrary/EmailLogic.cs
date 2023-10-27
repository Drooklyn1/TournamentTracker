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
                subject = $"{teamName} has a new matchup with {opponent}";

                body.AppendLine($"<h1>Your Team {teamName} has a new matchup</h1>\r\n");
                body.AppendLine("\r\n");
                body.Append($"<strong>Opponent: </strong>");
                body.AppendLine(opponent + "\r\n");
                body.AppendLine("\r\n");
                body.AppendLine("\r\n");
                body.AppendLine("Good luck!\r\n");
                body.AppendLine("\r\n");
                body.AppendLine("~TournamentTracker");
            }
            else
            {
                subject = $"{teamName} has a bye this round";

                body.AppendLine($"<h1>Your Team {teamName} has a bye this round</h1>\r\n");
                body.AppendLine("\r\n");
                body.AppendLine("\r\n");
                body.AppendLine("Enjoy the week off!\r\n");
                body.AppendLine("\r\n");
                body.AppendLine("~TournamentTracker");
            }

            try
            {
                SendEmail(to, subject, body.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void EmailUserTournamentFinished(Person p, string teamName, string winner)
        {
            if (p.Email.Length == 0)
            {
                return;
            }

            List<string> to = new List<string>();
            string subject;
            StringBuilder body = new StringBuilder();

            to.Add(p.Email);

            subject = $"The tournament is over, we have a Winner!";

            body.AppendLine($"<h1>The tournament is complete, thank you for participating with your team {teamName} !</h1>\n");
            body.AppendLine("\n");
            body.Append($"<strong>The Winner is: </strong>");
            body.AppendLine(winner + "\n");
            body.AppendLine("\n");
            body.AppendLine("\n");
            body.AppendLine("Until next time!\n");
            body.AppendLine("\n");
            body.AppendLine("~TournamentTracker");

            try
            {
                SendEmail(to, subject, body.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
