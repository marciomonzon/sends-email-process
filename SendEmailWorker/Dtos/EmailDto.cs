using System.ComponentModel.DataAnnotations;

namespace SendEmailWorker.Dtos
{
    public class EmailDto
    {
        [Required]
        public string Body { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string RecipientEmail { get; set; } = string.Empty;

        [Required]
        public DateTime NotificationSendDate { get; set; } = DateTime.Now;
    }
}
