namespace RentalMVC.Application.ViewModels.Address;

public class NewAddressVm 
{
    public string? AddressPartOne { get; set; }
    public string? AddressPartTwo { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public bool Active { get; set; }
}