using Microsoft.AspNetCore.Mvc;
using Models.ApplicationUserModels;
using Services.RegistrationServices;

namespace BonAppetitAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRegistrationService _registrationServices;
        public AuthenticationController(IRegistrationService registrationServices)
        {
            _registrationServices = registrationServices;
        }

        [HttpPost("RegisterManager/{restaurantId}")]
        public async Task<IActionResult> RegisterManager([FromBody] ApplicationUserCreateDto managerToRegister, string restaurantId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(restaurantId))
            {
                ModelState.AddModelError("restaurantId", "The restaurantId field is required.");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request =
                await _registrationServices.RegisterManagerAsync(managerToRegister, restaurantId, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }

        [HttpPost("RegisterClient")]
        public async Task<IActionResult> RegisterClient([FromBody] ApplicationUserCreateDto managerToRegister, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request =
                await _registrationServices.RegisterClientAsync(managerToRegister, cancellationToken);
            return StatusCode(request.StatusCode, request);
        }
    }
}
