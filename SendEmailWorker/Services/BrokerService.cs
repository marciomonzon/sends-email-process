using RabbitMQ.Client;
using SendEmailWorker.Dtos;
using System.Text;
using System.Text.Json;

namespace SendEmailWorker.Services
{
    public class BrokerService
    {
        public async Task<EmailDto> GetEmailNotificationAsync()
        {
            var messageFromQueue = await GetMessageFromQueueAsync("email");

            return (messageFromQueue != null && messageFromQueue != string.Empty) ?
                   JsonSerializer.Deserialize<EmailDto>(messageFromQueue)!
                   : new EmailDto();
        }

        private async Task<string> GetMessageFromQueueAsync(string queueName)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: queueName,
                                            durable: false,
                                            exclusive: false,
                                            autoDelete: false,
                                            arguments: null);

            var result = await channel.BasicGetAsync(queue: queueName, autoAck: true);

            if (result != null)
            {
                var body = result.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                return message;
            }

            return string.Empty;

        }
    }
}
