using Models.ResponseModels;
using Models.TableModels;

namespace Services.TableServices;

public interface ITableService
{
    Task<Response<Table>> GetRestaurantTables();
    Task<Response<Table>> CreateTableAsync(TableCreate tableToCreate);
    Task<Response<Table>> UpdateTableAsync(TableUpdate tableToUpdate);

}