using Models.ResponseModels;
using Models.TableModels;

namespace Services.TableServices;

public interface ITableService
{
    Task<Response<Table>> GetSingleTableAsync(string tableId);
}