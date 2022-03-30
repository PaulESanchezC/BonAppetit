namespace Models.ApiRequestModels;

public interface IApiRequestBase<T>
where T: class
{
    string ApiUrl { get; set; }
    HttpMethod HttpMethod { get; set; }
    T Data { get; set; }
    string? RestaurantServiceIdToken { get; set; }
    string? JwtToken { get; set; }
}