using System.Net;
using System.Net.Mail;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void SendEmail(string fromEmail, string fromName, List<string> to, string subject, string body) 
        {
            MailMessage message = new MailMessage();

            MailAddress fromAddress = new MailAddress(fromEmail, fromName);

            to.ForEach( toEmail => message.To.Add(toEmail) );

            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("f.dreiling@gmail.com", "yqexozstxtgjthvp");
            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
        }

    }
}
