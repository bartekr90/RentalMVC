using RentalMVC.Domain.Model.Common;

namespace RentalMVC.Domain.Model.Entity.UserEntities;

public class Address : BaseEntity
{
    public required string AddressPartOne { get; set; }
    public required string AddressPartTwo { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }    
}