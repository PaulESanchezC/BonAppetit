using Models.ResponseModels;
using Models.TableReservationBracketsModels;

namespace Services.TableTimeBracketsService;

public interface ITableTimeBracketService
{
    Task<Response<TableReservationBracketDto>> GetAllTableReservationBracketsForRestaurantAsync
        (string restaurantId, DateTime dateOfRequest, CancellationToken cancellationToken);
}