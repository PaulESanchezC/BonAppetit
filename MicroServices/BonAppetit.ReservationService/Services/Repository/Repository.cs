using System.Linq.Expressions;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ResponseModels;

namespace Services.Repository;

public class Repository<T, TDto, TCreate> : IRepository<T, TDto, TCreate>
    where T : class
    where TDto : class
    where TCreate : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _db;
    public Repository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<TDto>> GetByAsync(Expression<Func<T, bool>>? predicate, CancellationToken cancellationToken)
    {
        var query = _db.Set<T>().AsQueryable().AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        if (!query.Any())
            return await ResponseSingleBuilderTask(true, 200, "Empty Result", "The operation returned an empty result", null);

        return await ResponseManyBuilderTask(true, 200, "Ok", "Ok", await query.ToListAsync(cancellationToken));
    }
    public Task<Response<TDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message, T? responseObject)
    {
        var responseObjectDto = new List<TDto>();
        if (responseObject is not null)
            responseObjectDto.Add(_mapper.Map<TDto>(responseObject));

        var response = new Response<TDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }
    public Task<Response<TDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message, List<T>? responseObject)
    {
        var responseObjectDto = new List<TDto>();
        if (responseObject != null)
            responseObjectDto.AddRange(responseObject.Select(item => _mapper.Map<TDto>(item)));

        var response = new Response<TDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }
}