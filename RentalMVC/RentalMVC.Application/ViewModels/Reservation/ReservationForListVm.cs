namespace RentalMVC.Application.ViewModels.Reservation;

public class ReservationForListVm 
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public required string ClientName { get; set; }
    public required string RentalName { get; set; }
    public required string Title { get; set; }
    public bool DuringExecution { get; set; }
    public string? Comments { get; set; }
    public decimal Value { get; set; }
    public int ClientId { get; set; }
    public int RentalId { get; set; }
    public int NumberOfPositions { get; set; }    
}
