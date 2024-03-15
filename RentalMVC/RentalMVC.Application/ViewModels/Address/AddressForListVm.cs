namespace RentalMVC.Application.ViewModels.Address;

public class AddressForListVm 
{
    public required string AddressPartOne { get; set; }
    public required string AddressPartTwo { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public int Id { get; set; }
    public bool Active { get; set; }
}
