using System.ComponentModel.DataAnnotations;
using Models.RestaurantModels;

namespace Models.TableModels;

public class TableDto
{
    #region Table Properties
    [Required(AllowEmptyStrings = false)]
    public string TableId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string TableName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int FrequencyOfReservation { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int AmountOfSeats { get; set; }

    public RestaurantDto Restaurant { get; set; } = new();

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }
    #endregion
}