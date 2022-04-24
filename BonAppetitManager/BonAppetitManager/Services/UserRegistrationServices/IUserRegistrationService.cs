using Models.ApplicationUserModels;
using Models.ResponseModels;

namespace Services.UserRegistrationServices;

public interface IUserRegistrationService
{
    Task<Response<ApplicationUser>> RegisterUserAsync(ApplicationUserCreate applicationUser);
}