using SendEmailWorker.Services;

namespace SendEmailWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var emailService = new SendEmailService();
            var brokerService = new BrokerService();

            while (!stoppingToken.IsCancellationRequested)
            {
                var emailFromQueue = await brokerService.GetEmailNotificationAsync();

                if(emailFromQueue.Body != string.Empty)
                {
                    emailService.SendEmail(new Dtos.EmailDto
                    {
                        Body = emailFromQueue.Body,
                        RecipientEmail = emailFromQueue.RecipientEmail,
                        Subject = emailFromQueue.Subject
                    });
                }
            }
        }
    }
}
