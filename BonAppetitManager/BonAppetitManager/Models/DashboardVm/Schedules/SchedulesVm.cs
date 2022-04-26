using System.ComponentModel.DataAnnotations;
using Models.RestaurantModels;

namespace Models.DashboardVm.Schedules;

public class SchedulesVm
{
    #region Schedule Properties

    [Required(AllowEmptyStrings = false)]
    public string RestaurantId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ScheduleId { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Sunday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string SundayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string SundayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Monday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string MondayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string MondayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Tuesday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string TuesdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string TuesdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Wednesday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string WednesdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string WednesdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Thursday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ThursdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ThursdayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Friday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string FridayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string FridayCloseTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public bool Saturday { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string SaturdayOpenTime { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string SaturdayCloseTime { get; set; }
    public Restaurant Restaurant { get; set; }

    #endregion
}