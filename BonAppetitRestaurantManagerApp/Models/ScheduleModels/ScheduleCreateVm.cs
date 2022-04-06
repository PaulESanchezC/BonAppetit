using System.ComponentModel.DataAnnotations;


namespace Models.ScheduleModels;

public class ScheduleCreateVm
{
    #region Schedule Properties
    [Required(AllowEmptyStrings = false)]
    public bool Sunday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int SundayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int SundayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Monday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int MondayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int MondayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Tuesday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int TuesdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int TuesdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Wednesday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int WednesdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int WednesdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Thursday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int ThursdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int ThursdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Friday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int FridayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int FridayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Saturday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int SaturdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public int SaturdayCloseTime { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }
    #endregion
}