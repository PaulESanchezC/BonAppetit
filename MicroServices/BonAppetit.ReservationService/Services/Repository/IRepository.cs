using System.Linq.Expressions;
using Models.ResponseModels;

namespace Services.Repository;

public interface IRepository<T, TDto, TCreate>
    where T : class
    where TDto : class
    where TCreate : class
{
    Task<Response<TDto>> GetByAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken);
    Task<Response<TDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        T? responseObject);
    Task<Response<TDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        List<T>? responseObject);
}