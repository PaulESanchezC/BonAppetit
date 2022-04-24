using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AccountsServices;

namespace BonAppetitAuthentication.Controllers
{
    [Route($"{IdentityServerConstants.LocalApi.ScopeName}/Accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly ProfileDataRequestContext _context;
        public AccountsController(IAccountsService accountsService, ProfileDataRequestContext context)
        {
            _accountsService = accountsService;
            _context = context;
        }

        [HttpGet("GetApplicationUserInformation/{userId}")]
        public async Task<IActionResult> GetApplicationUserInformation(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("userId", "The userId field is required.");
                return BadRequest(ModelState);
            }
            var request = await _accountsService.GetApplicationUser(userId);
            return StatusCode(request.StatusCode, request);
        }
    }
}
