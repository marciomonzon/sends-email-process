using SendEmailWorker.Dtos;
using System.Net.Mail;
using System.Net;

namespace SendEmailWorker.Services
{
    public class SendEmailService
    {
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;

        public bool SendEmail(EmailDto dto)
        {
            try
            {
                using (var smtpClient = new SmtpClient(SMTP_SERVER, SMTP_PORT))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("email@email.com", "password");
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("emailteste@test.com"),
                        Subject = dto.Subject,
                        Body = dto.Body,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(dto.RecipientEmail);

                    //await smtpClient.SendMailAsync(mailMessage);
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
