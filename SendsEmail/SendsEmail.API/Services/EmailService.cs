using SendsEmail.API.Services.Interfaces;
using System.Net.Mail;
using System.Net;

namespace SendsEmail.API.Services
{
    public class EmailService : IEmailService
    {
        private string? _senderEmail;
        private string? _senderPassword;
        private string? _smtpServer;
        private int _smtpPort;

        public void SetConfiguration()
        {
            _senderEmail = "email@email.com";
            _senderPassword = "password";
            _smtpServer = "localhost";
            _smtpPort = 587;
        }

        public async Task<bool> SendEmailAsync(string subject, string body, string recipientEmail)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_senderEmail!),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(recipientEmail);

                    await smtpClient.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
