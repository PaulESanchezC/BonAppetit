using Models.RestaurantModels;

namespace Models.TableModels;

public class TableBase
{
    #region Table Properties
    public string TableId { get; set; } = Guid.NewGuid().ToString();
    public string TableName { get; set; } = "";
    public double FrequencyOfReservation { get; set; } = 2;
    public int AmountOfSeats { get; set; } = 2;

    public RestaurantBase Restaurant { get; set; }
    public string RestaurantId { get; set; }

    #endregion


    #region Bussiness Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    #endregion
}