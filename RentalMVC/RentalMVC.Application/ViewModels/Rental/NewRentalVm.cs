using RentalMVC.Application.ViewModels.ContactData;

namespace RentalMVC.Application.ViewModels.Rental;

public class NewRentalVm 
{
    public required string Name { get; set; }
    public bool Active { get; set; }
    public int MainContactDataId { get; set; }
    public virtual required ContactDataForListVm MainContactData { get; set; }
    public virtual required ListContactDataVm Contacts { get; set; }
}
