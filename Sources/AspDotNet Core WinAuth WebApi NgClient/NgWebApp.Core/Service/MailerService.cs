using System.Net;
using DotLiquid.Mailer.Core;
using $safeprojectname$.Interface;

namespace $safeprojectname$.Service
{
    public class MailerService: IMailerService
    {
        public IMailEngine Engine { get; }

        public MailerService(string smtpServer, int smtpPort, string templateDir = ".", 
            string defaultFrom = "", bool ssl = false, bool defaultCredentials = true, 
            NetworkCredential credentials = null )
        {
            Engine = new MailEngine
            {
                IsHtml = true,
                SmtpServer = smtpServer,
                SmtpPort = smtpPort,
                TemplateDir = templateDir,
                DefaultFromAddress = defaultFrom,
                EnableSsl = ssl,
                UseDefaultCredentials = defaultCredentials,
                Credentials = defaultCredentials ? null : credentials
            };
        }
    }
}
