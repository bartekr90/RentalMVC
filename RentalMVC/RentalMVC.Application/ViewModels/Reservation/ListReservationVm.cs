namespace RentalMVC.Application.ViewModels.Reservation;

public class ListReservationVm
{
    public List<ReservationForListVm> Reservations { get; set; } = new List<ReservationForListVm>();
    public int Count { get; set; }
}
