namespace Models.ApiRequestModels;

public interface IApiRequestBase
{
    string RouteName { get; set; }
    HttpMethod HttpMethod { get; set; }
    object? PostBody { get; set; }
    List<string> GetQueries { get; set; }
    string? RestaurantServiceIdToken { get; set; }
    string? JwtToken { get; set; }
}