using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace CollaboratorService.Infrastructure.Email
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendInviteAsync(string toEmail, int noteId)
        {
            var from = _config["Email:From"];
            var user = _config["Email:Username"];
            var pass = _config["Email:Password"];
            var host = _config["Email:SmtpServer"];
            var port = int.Parse(_config["Email:Port"]);

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Fundoo", from));
            email.To.Add(MailboxAddress.Parse(toEmail));

            email.Subject = "Fundoo Collaboration Invite";

            email.Body = new TextPart("plain")
            {
                Text = $"You were added as collaborator for Note ID {noteId}"
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(host, port, false);
            await smtp.AuthenticateAsync(user, pass);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}