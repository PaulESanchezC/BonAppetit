namespace Models.ResponseModels;

public interface IResponseBase<T> where T: class
{
    bool IsSuccessful { get; set; }
    int StatusCode { get; set; }
    string Title { get; set; }
    string Message { get; set; }
    List<T>? ResponseObject { get; set; }
}