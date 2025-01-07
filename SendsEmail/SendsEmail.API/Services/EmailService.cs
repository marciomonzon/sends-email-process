using SendsEmail.API.Dtos;
using SendsEmail.API.Services.Interfaces;

namespace SendsEmail.API.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> NotifyToSendEmailAsync(EmailDto dto)
        {
            return false;
        }
    }
}
