using Models.RestaurantModels;

namespace Models.ScheduleModels;

public class ScheduleBase
{
    #region Schedule Properties

    public string ScheduleId { get; set; } = Guid.NewGuid().ToString();
    public bool Sunday { get; set; }
    public double SundayOpenTime { get; set; }
    public double SundayCloseTime { get; set; }
    public bool Monday { get; set; }
    public double MondayOpenTime { get; set; }
    public double MondayCloseTime { get; set; }
    public bool Tuesday { get; set; }
    public double TuesdayOpenTime { get; set; }
    public double TuesdayCloseTime { get; set; }
    public bool Wednesday { get; set; }
    public double WednesdayOpenTime { get; set; }
    public double WednesdayCloseTime { get; set; }
    public bool Thursday { get; set; }
    public double ThursdayOpenTime { get; set; }
    public double ThursdayCloseTime { get; set; }
    public bool Friday { get; set; }
    public double FridayOpenTime { get; set; }
    public double FridayCloseTime { get; set; }
    public bool Saturday { get; set; }
    public double SaturdayOpenTime { get; set; }
    public double SaturdayCloseTime { get; set; }

    public RestaurantBase Restaurant { get; set; }
    public string RestaurantId { get; set; }
    #endregion


    #region Bussiness Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    #endregion
}