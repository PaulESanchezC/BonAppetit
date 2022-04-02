namespace Models.ApiRequestModels;

public class ApiRequest : IApiRequestBase
{
    public string ApiUrl { get; set; }
    public HttpMethod HttpMethod { get; set; }
    public object? PostBody { get; set; }
    public List<string> GetQueries { get; set; }
    public string? RestaurantServiceIdToken { get; set; }
    public string? JwtToken { get; set; }
}