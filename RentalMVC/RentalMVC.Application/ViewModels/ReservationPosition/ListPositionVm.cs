namespace RentalMVC.Application.ViewModels.ReservationPosition;

public class ListPositionVm
{
    public List<PositionVm> Positions { get; set; } = new List<PositionVm>();
    public int Count { get; set; }
}
