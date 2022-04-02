using Models.AuthenticationModels;
using Models.ResponseModels;

namespace Services.AuthenticationServices;

public interface IAuthenticationServices
{
    Task<Response<LoginResponse>> LoginAsync(LoginAttempt loginAttempt);
    Task LogoutAsync();
}
