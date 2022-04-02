namespace Services.ApiRouteProvider;

public interface IApiRouteProvider
{
    Task<string?> GetApiRoute(string routeName);
}