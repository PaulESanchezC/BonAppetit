namespace Models.TableModels;

public class TableCreate
{
    #region Table Properties
    public string TableName { get; set; }
    public double HoursOpenForReservation { get; set; }
    public int FrequencyOfReservation { get; set; }
    public int AmountOfSeats { get; set; }
    #endregion
}