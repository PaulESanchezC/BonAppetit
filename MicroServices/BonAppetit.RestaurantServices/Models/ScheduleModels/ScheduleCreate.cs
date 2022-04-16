using System.ComponentModel.DataAnnotations;


namespace Models.ScheduleModels;

public class ScheduleCreate
{
    #region Schedule Properties

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }
    [Required(AllowEmptyStrings = false)]
    public bool Sunday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double SundayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double SundayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Monday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double MondayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double MondayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Tuesday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double TuesdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double TuesdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Wednesday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double WednesdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double WednesdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Thursday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double ThursdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double ThursdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Friday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double FridayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double FridayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Saturday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double SaturdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public double SaturdayCloseTime { get; set; }

    #endregion
}