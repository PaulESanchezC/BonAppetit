namespace Models.TableModels;

public class TableDto
{
    #region Table Properties
    public string TableId { get; set; }
    public string TableName { get; set; }
    public double HoursOpenForReservation { get; set; }
    public int FrequencyOfReservation { get; set; }
    public int AmountOfSeats { get; set; }
    #endregion
}