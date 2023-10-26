using System.Net;
using System.Net.Mail;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void SendEmail(List<string> to, string subject, string body) 
        {
            MailMessage message = new MailMessage();

            MailAddress fromAddress = new MailAddress(GlobalConfig.UserEmail(), GlobalConfig.UserName());

            to.ForEach( toEmail => message.To.Add(toEmail) );

            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = GlobalConfig.EmailHost();
            smtpClient.Port = GlobalConfig.EmailPort();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(GlobalConfig.UserEmail(), GlobalConfig.UserKey());
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Send(message);
        }

    }
}
