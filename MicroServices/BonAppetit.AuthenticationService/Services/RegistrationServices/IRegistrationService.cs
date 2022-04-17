using Models.ApplicationUserModels;
using Models.ResponseModels;

namespace Services.RegistrationServices;

public interface IRegistrationService
{
    Task<Response<ApplicationUserDto>> RegisterManagerAsync(ApplicationUserCreateDto managerToCreate,
        string restaurantId, CancellationToken cancellationToken);

    Task<Response<ApplicationUserDto>> RegisterClientAsync(ApplicationUserCreateDto clientToCreate, CancellationToken cancellationToken);

    Task<Response<ApplicationUserDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        ApplicationUser? responseObject);
}