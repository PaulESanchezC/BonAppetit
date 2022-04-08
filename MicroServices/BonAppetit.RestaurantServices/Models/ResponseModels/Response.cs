namespace Models.ResponseModels;

public class Response<T>
where T : class
{
    public bool IsSuccessful { get; set; }
    public int StatusCode { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public List<T>? ResponseObject { get; set; }
}