using System.ComponentModel.DataAnnotations;

namespace Models.TableModels;

public class TableUpdate
{
    #region Table Properties

    [Required(AllowEmptyStrings = false)]
    public string TableName { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double FrequencyOfReservation { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int AmountOfSeats { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }
    #endregion
}