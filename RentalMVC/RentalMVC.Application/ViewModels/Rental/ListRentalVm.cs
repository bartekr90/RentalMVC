namespace RentalMVC.Application.ViewModels.Rental;

public class ListRentalVm
{
    public List<RentalForListVm> Rentals { get; set; } = new List<RentalForListVm>();
    public int Count { get; set; }
}