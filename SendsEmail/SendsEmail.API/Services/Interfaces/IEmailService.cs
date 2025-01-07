using SendsEmail.API.Dtos;

namespace SendsEmail.API.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> NotifyToSendEmailAsync(EmailDto dto);
    }
}
