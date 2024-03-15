namespace RentalMVC.Application.ViewModels.ReservationPosition;

public class ListPositionExtendedVm
{
    public List<PositionExtendedVm> Positions { get; set; } = new List<PositionExtendedVm>();
    public int Count { get; set; }
}
