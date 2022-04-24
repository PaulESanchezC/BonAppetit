using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApplicationUserModels;
using Services.RegistrationServices;

namespace RegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegisterUserController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("RegisterManager")]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUserCreateDto applicationUserCreate,
            CancellationToken cancellationToken)
        {
            var request = await _registrationService.RegisterManagerAsync(applicationUserCreate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }


        [HttpPost("RegisterClient")]
        public async Task<IActionResult> RegisterClient([FromBody] ApplicationUserCreateDto applicationUserCreate,
            CancellationToken cancellationToken)
        {
            var request = await _registrationService.RegisterClientAsync(applicationUserCreate, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
