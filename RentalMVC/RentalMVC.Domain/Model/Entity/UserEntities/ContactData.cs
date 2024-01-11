using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity.UserEntities;

public class ContactData : BaseEntity
{
    public required string NamePart1 { get; set; }
    public required string NamePart2 { get; set; }
    public required string Email { get; set; }
    public required string PhoneNr { get; set; }
    public int AddressId { get; set; }
    public virtual required Address Address { get; set; }
}