using Models.ResponseModels;
using Models.TableReservationBracketsModels;

namespace Services.TableTimeBracketsService;
//TODO: Separate this to another service
public interface ITableTimeBracketService
{
    Task<Response<TableReservationBracketDto>> GetAllTableReservationBracketsForRestaurantAsync
        (string restaurantId, DateTime dateOfRequest, CancellationToken cancellationToken);
}