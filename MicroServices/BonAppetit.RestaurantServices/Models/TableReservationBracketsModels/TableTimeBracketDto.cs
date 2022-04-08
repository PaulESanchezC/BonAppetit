using Models.ReservationModels;

namespace Models.TableReservationBracketsModels;

public class TableTimeBracketDto
{
    public bool IsAvailable { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public ReservationDto? Reservation { get; set; }
}