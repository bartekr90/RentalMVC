using RentalMVC.Application.ViewModels.Address;
using RentalMVC.Application.ViewModels.Common;

namespace RentalMVC.Application.ViewModels.ContactData;

public class EditContactDataVm : IBaseVm, IAuditableVm
{
    public required string NamePart1 { get; set; }
    public required string NamePart2 { get; set; }
    public required string Email { get; set; }
    public required string PhoneNr { get; set; }
    public int AddressId { get; set; }
    public AddressForListVm? Address { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
    public required string CreatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifierId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}
