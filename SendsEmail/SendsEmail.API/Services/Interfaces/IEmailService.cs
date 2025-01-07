namespace SendsEmail.API.Services.Interfaces
{
    public interface IEmailService
    {
        void SetConfiguration();
        Task<bool> SendEmailAsync(string subject, string body, string recipientEmail);
    }
}
