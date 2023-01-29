using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MimeKit;
using MailKit;
using MailKit.Security;
using System.Security.Authentication;

namespace ServerApp.Services.Email
{
   
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public EmailSettings _smtpSettings { get; } //set only via Secret Manager

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var _mail = new MimeMessage() { };
                _mail.From.Add(MailboxAddress.Parse("info@expertsconsult.co"));
                _mail.To.Add(MailboxAddress.Parse("sales@expertsconsult.co"));
                _mail.Subject = subject;
                _mail.Body = new TextPart("html") {Text = body };
                //new ProtocolLogger("smtp.log")
                using (var client = new SmtpClient())
                {
                   // client.Timeout = 1000 * 20;
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync("expertsconsult.co", 465);
                    await client.AuthenticateAsync("info@expertsconsult.co", "Expertsconult@2022");
                    await client.SendAsync(_mail);
                    await client.DisconnectAsync(true);
                }
    


            }
            catch (Exception e) { throw new InvalidOperationException(e.Message); }
        }
     }

    public class EmailSettings
    {
        public string? Server { get; set; }

        public string? Port { get; set; }

        public string? SenderName { get; set; }
        public string ?SenderEmail { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }


    }
}
 


