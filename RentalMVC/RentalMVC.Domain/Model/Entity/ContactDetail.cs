using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity;

public class ContactDetail : BaseEntity
{
    public required string FirstName { get; set; }
    public required string SecondName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNr { get; set; }
    public int AdressId { get; set; }
    public virtual required Adress Adress { get; set; }
}
