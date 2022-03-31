using AutoMapper;
using Data;
using Models.TableModels;

namespace Services.Repository.TableRepository;

public class TableService : Repository<TableBase, TableDto, TableCreate>, ITableService
{
    public TableService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}