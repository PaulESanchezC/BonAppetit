using Models.ReservationModels;
using Models.TableModels;

namespace Models.DashboardVm.Reservations;

public class ReservationVm
{
    public Reservation Reservation { get; set; }
    public Table Table { get; set; }
}