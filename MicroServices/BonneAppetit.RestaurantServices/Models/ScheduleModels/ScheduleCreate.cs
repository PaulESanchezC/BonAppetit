using Models.RestaurantModels;

namespace Models.ScheduleModels;

public class ScheduleCreate
{
    #region Schedule Properties
    public bool Sunday { get; set; }
    public DateTime SundayOpenTime { get; set; }
    public DateTime SundayCloseTime { get; set; }
    public bool Monday { get; set; }
    public DateTime MondayOpenTime { get; set; }
    public DateTime MondayCloseTime { get; set; }
    public bool Tuesday { get; set; }
    public DateTime TuesdayOpenTime { get; set; }
    public DateTime TuesdayCloseTime { get; set; }
    public bool Wednesday { get; set; }
    public DateTime WednesdayOpenTime { get; set; }
    public DateTime WednesdayCloseTime { get; set; }
    public bool Thursday { get; set; }
    public DateTime ThursdayOpenTime { get; set; }
    public DateTime ThursdayCloseTime { get; set; }
    public bool Friday { get; set; }
    public DateTime FridayOpenTime { get; set; }
    public DateTime FridayCloseTime { get; set; }
    public bool Saturday { get; set; }
    public DateTime SaturdayOpenTime { get; set; }
    public DateTime SaturdayCloseTime { get; set; }
    public string RestaurantId { get; set; }
    #endregion
}