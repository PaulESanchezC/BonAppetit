using Duende.IdentityServer.Models;
using Models.ApplicationUserModels;
using Models.ResponseModels;

namespace Services.AccountsServices;

public interface IAccountsService
{
    Task<Response<ApplicationUserDto>> GetApplicationUser(string userId);
    Task<Response<ApplicationUserDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        ApplicationUser? responseObject);
}