using Models.ResponseModels;
using Models.TableModels;

namespace Services.Repository.TableRepository;

public interface ITableService : IRepository<TableBase, TableDto, TableCreate> {}