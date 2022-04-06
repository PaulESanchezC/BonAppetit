using Models.ResponseModels;

namespace Models.AuthenticationModels;

public class LoginResponse : IResponseBase<string>
{
    public bool IsSuccessful { get; set; }
    public int StatusCode { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public List<string>? ResponseObject { get; set; }
}