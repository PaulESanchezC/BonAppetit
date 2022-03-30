namespace Models.ApiRequestModels;

public class ApiRequest<T> : IApiRequestBase<T>
    where T:class 
{
    public string ApiUrl { get; set; }
    public HttpMethod HttpMethod { get; set; }
    public T Data { get; set; }
    public string? RestaurantServiceIdToken { get; set; }
    public string? JwtToken { get; set; }
}