using Microsoft.AspNetCore.Mvc;
using SendsEmail.API.Dtos;
using SendsEmail.API.Services.Interfaces;

namespace SendsEmail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailNotificationController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> NotifySendEmailAsync([FromBody] EmailDto email)
        {
            var result = await _emailService.NotifyToSendEmailAsync(email);

            return result ? Ok("Email notification sent successfully") : BadRequest();
        }
    }
}
