using System.Net;
using System.Net.Mail;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void EmailUserNewRound(string email, string teamName, string opponent)
        {
            if (email.Length == 0)
            {
                return;
            }

            List<string> to = new List<string>();
            string subject;
            StringBuilder body = new StringBuilder();

            to.Add(email);

            if (opponent != "")
            {
                subject = $"{teamName} has a new matchup with {opponent}";

                body.AppendLine($"<h1>Your Team {teamName} has a new matchup</h1>");
                body.AppendLine("</br>");
                body.Append($"<strong>Opponent: </strong>");
                body.AppendLine(opponent + "</br>");
                body.AppendLine("</br>");
                body.AppendLine("</br>");
                body.AppendLine("Good luck!</br>");
                body.AppendLine("</br>");
                body.AppendLine("~TournamentTracker");
            }
            else
            {
                subject = $"{teamName} has a bye this round";

                body.AppendLine($"<h1>Your Team {teamName} has a bye this round</h1>");
                body.AppendLine("</br>");
                body.AppendLine("</br>");
                body.AppendLine("Enjoy the week off!</br>");
                body.AppendLine("</br>");
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

        public static void EmailUserTournamentFinished(string email, string teamName, string winner, string runnerUp, decimal winnerAmount, decimal runnerUpAmount)
        {
            if (email.Length == 0)
            {
                return;
            }

            List<string> to = new List<string>();
            string subject;
            StringBuilder body = new StringBuilder();

            to.Add(email);

            subject = $"The tournament is over, we have a Winner!";

            body.AppendLine($"<h1>The tournament is complete, thank you for participating with your team {teamName} !</h1>");
            body.AppendLine("</br>");
            body.Append($"<p><strong>The Winner is: { winner }</strong></p>");
            body.AppendLine("</br>");
            body.Append($"<p><strong>The Runner-Up is: { runnerUp }</strong></p>");
            body.AppendLine("</br>");

            if (winnerAmount > 0)
            {
                body.Append($"<p>The Winner will receive { winnerAmount }</p>");
                body.AppendLine("</br>");
            }
            if (runnerUpAmount > 0)
            {
                body.Append($"<p>The Runner-Up will receive { runnerUpAmount }</p>");
                body.AppendLine("</br>");
            }

            body.AppendLine("<p>Until next time!</p>");
            body.AppendLine("</br>");
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

            MailAddress fromAddress = new MailAddress(GlobalConfig.EmailConfig.UserEmail, GlobalConfig.EmailConfig.UserName);

            to.ForEach( toEmail => message.To.Add(toEmail) );

            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = GlobalConfig.EmailConfig.UserHost;
            smtpClient.Port = GlobalConfig.EmailConfig.UserPort;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(GlobalConfig.EmailConfig.UserEmail, GlobalConfig.EmailConfig.UserPassword);
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
