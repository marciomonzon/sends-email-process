using System.ComponentModel.DataAnnotations;

namespace SendsEmail.API.Dtos
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
