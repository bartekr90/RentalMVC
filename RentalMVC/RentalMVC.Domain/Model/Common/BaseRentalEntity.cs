using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Model.Common;

public class BaseRentalEntity : BaseEntity
{
    public int RentalId { get; set; }
    public virtual required Rental Rental { get; set; }
}