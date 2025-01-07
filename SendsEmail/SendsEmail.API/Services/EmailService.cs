using RabbitMQ.Client;
using SendsEmail.API.Dtos;
using SendsEmail.API.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace SendsEmail.API.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> NotifyToSendEmailAsync(EmailDto dto)
        {
            try
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(queue: "email",
                                                durable: false,
                                                exclusive: false,
                                                autoDelete: false,
                                                arguments: null);

                var messageJson = JsonSerializer.Serialize(dto);

                var body = Encoding.UTF8.GetBytes(messageJson);

                await channel.BasicPublishAsync(exchange: string.Empty,
                                                routingKey: "email",
                                                body: body);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
