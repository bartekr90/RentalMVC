namespace RentalMVC.Application.ViewModels.Client;

public class ClientForListVm
{
    public required string Name { get; set; }
    public int MainContactDataId { get; set; }
    public  string? Address { get; set; }
    public bool HasReservations { get; set; }
    public int Id { get; set; }   
}