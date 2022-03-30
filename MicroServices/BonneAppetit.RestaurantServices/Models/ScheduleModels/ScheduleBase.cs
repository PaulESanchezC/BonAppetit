using Models.RestaurantModels;

namespace Models.ScheduleModels;

public class ScheduleBase
{
    #region Schedule Properties

    public string ScheduleId { get; set; } = Guid.NewGuid().ToString();
    public bool Sunday { get; set; }
    public int SundayOpenTime { get; set; }
    public int SundayCloseTime { get; set; }
    public bool Monday { get; set; }
    public int MondayOpenTime { get; set; }
    public int MondayCloseTime { get; set; }
    public bool Tuesday { get; set; }
    public int TuesdayOpenTime { get; set; }
    public int TuesdayCloseTime { get; set; }
    public bool Wednesday { get; set; }
    public int WednesdayOpenTime { get; set; }
    public int WednesdayCloseTime { get; set; }
    public bool Thursday { get; set; }
    public int ThursdayOpenTime { get; set; }
    public int ThursdayCloseTime { get; set; }
    public bool Friday { get; set; }
    public int FridayOpenTime { get; set; }
    public int FridayCloseTime { get; set; }
    public bool Saturday { get; set; }
    public int SaturdayOpenTime { get; set; }
    public int SaturdayCloseTime { get; set; }

    public RestaurantBase Restaurant { get; set; }
    #endregion


    #region Bussiness Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    #endregion
}