namespace Models.ResponseModels;

public interface IResponseBase<TDto> where TDto: class
{
    bool IsSuccessful { get; set; }
    int StatusCode { get; set; }
    string Title { get; set; }
    string Message { get; set; }
    List<TDto>? ResponseObject { get; set; }
}