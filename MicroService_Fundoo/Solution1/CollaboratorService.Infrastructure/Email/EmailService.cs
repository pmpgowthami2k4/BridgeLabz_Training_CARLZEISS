//using MailKit.Net.Smtp;
//using Microsoft.Extensions.Configuration;
//using MimeKit;

//namespace CollaboratorService.Infrastructure.Email
//{
//    public class EmailService
//    {
//        private readonly IConfiguration _config;

//        public EmailService(IConfiguration config)
//        {
//            _config = config;
//        }

//        public async Task SendInviteAsync(string toEmail, int noteId)
//        {
//            var from = _config["Email:From"];
//            var user = _config["Email:Username"];
//            var pass = _config["Email:Password"];
//            var host = _config["Email:SmtpServer"];
//            var port = int.Parse(_config["Email:Port"]);

//            var email = new MimeMessage();

//            email.From.Add(new MailboxAddress("Fundoo", from));
//            email.To.Add(MailboxAddress.Parse(toEmail));

//            email.Subject = "Fundoo Collaboration Invite";

//            email.Body = new TextPart("plain")
//            {
//                Text = $"You were added as collaborator for Note ID {noteId}"
//            };

//            using var smtp = new SmtpClient();

//            await smtp.ConnectAsync(host, port, false);
//            await smtp.AuthenticateAsync(user, pass);
//            await smtp.SendAsync(email);
//            await smtp.DisconnectAsync(true);
//        }
//    }
//}

using MailKit.Net.Smtp;
using MailKit.Security;
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
            try
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

                email.Body = new TextPart("html")
                {
                    Text = $@"
                        <h3>You've been added as a collaborator 🎉</h3>
                        <p>You now have access to <b>Note ID: {noteId}</b></p>
                    "
                };

                using var smtp = new SmtpClient();

                // Secure connection
                await smtp.ConnectAsync(host, port, SecureSocketOptions.StartTls);

                //  Authenticate
                await smtp.AuthenticateAsync(user, pass);

                //  Send email
                await smtp.SendAsync(email);

                //  Disconnect
                await smtp.DisconnectAsync(true);

                Console.WriteLine("✅ Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Email failed: {ex.Message}");
                throw; // rethrow so you can catch upstream if needed
            }
        }
    }
}