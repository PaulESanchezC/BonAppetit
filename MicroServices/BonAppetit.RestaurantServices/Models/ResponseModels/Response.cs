namespace Models.ResponseModels;

public class Response<TDto> : IResponseBase<TDto>
where TDto : class
{
    public bool IsSuccessful { get; set; }
    public int StatusCode { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public List<TDto>? ResponseObject { get; set; }
}