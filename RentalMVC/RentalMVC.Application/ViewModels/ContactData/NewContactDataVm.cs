using RentalMVC.Application.ViewModels.Address;

namespace RentalMVC.Application.ViewModels.ContactData;

public class NewContactDataVm 
{
    public required string NamePart1 { get; set; }
    public required string NamePart2 { get; set; }
    public required string Email { get; set; }
    public required string PhoneNr { get; set; }
    public int AddressId { get; set; }
    public required NewAddressVm Address { get; set; }
}
