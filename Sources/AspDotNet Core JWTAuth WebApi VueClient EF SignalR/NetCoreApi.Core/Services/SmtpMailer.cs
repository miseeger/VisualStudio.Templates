using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace $safeprojectname$.Services

{
    public class SmtpMailer : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("localhost")
            {
                // UseDefaultCredentials = false,
                // Credentials = new NetworkCredential("yourusername", "yourpassword")
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("mc.admin@mydomain.xyz"),
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            return client.SendMailAsync(mailMessage);
        }
    }
}