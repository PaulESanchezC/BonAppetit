using System.Linq.Expressions;
using Models.ResponseModels;

namespace Services.Repository;

public interface IRepository<T,TDto, TCreate, TUpdate>
where T:class
where TDto: class
where TCreate : class
where TUpdate : class
{
    Task<Response<TDto>> GetAllByAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken, params Expression<Func<T,object>>[] includes);
    Task<Response<TDto>> GetSingleByAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T,object>>[] includes);
    Task<Response<TDto>> CreateAsync(TCreate objectToCreate, CancellationToken cancellationToken);
    Task<Response<TDto>> UpdateAsync(TUpdate objectToUpdate, CancellationToken cancellationToken);
    Task<Response<TDto>> DeleteAsync(string objectId, CancellationToken cancellationToken);
    Task<Response<TDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        T? responseObject);
    Task<Response<TDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        List<T>? responseObject);
}