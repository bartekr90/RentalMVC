using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.ContactData;

public class ContactDataForListVm : IBaseVm
{
    public required string NamePart1 { get; set; }
    public required string NamePart2 { get; set; }
    public required string Email { get; set; }
    public required string PhoneNr { get; set; }
    public int AddressId { get; set; }
    public string? AddressPart1 { get; set; }
    public string? AddressPart2 { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}