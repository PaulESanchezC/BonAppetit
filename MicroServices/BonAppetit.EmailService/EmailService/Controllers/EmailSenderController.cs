using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EmailModels;
using Services.EmailServices;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IMailJetEmailSender _emailSender;
        public EmailSenderController(IMailJetEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody]List<Email> emails,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = await _emailSender.MailJetMailSender(emails, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
