namespace RentalMVC.Application.ViewModels.Address;

public class ListAddressVm
{
    public List<AddressForListVm> Addresses { get; set; } = new List<AddressForListVm>();
    public int Count { get; set; }
}