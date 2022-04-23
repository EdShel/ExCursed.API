using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;
using ExCursed.BLL.Interfaces;
using System.Text;
using System;

namespace ExCursed.BLL.Services
{
    public sealed class EmailService : IEmailService
    {
        private EmailOptions options;

        public EmailService(IConfiguration configuration)
        {
            options = new EmailOptions();
            configuration.Bind("Email", options);
        }

        public async Task SendAsync(string receiver, string subject, string bodyHtml)
        {
            if (!options.Enabled)
            {
                return;
            }

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(options.Name, options.Email));
            emailMessage.To.Add(new MailboxAddress(string.Empty, receiver));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = bodyHtml
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(options.Server, options.Port, options.UseSSL);
                string password = Encoding.UTF8.GetString(Convert.FromBase64String(options.Password));
                await client.AuthenticateAsync(options.Email, password);

                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        private class EmailOptions
        {
            public bool Enabled { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Server { get; set; }

            public int Port { get; set; }

            public bool UseSSL { get; set; }
        }
    }
}
