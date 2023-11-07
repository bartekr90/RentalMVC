using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Tests;
internal static class SampleDataSet
{
    //stworzyæ tablice string[] titles, comments itd do testów
    public static Reservation GetReservation01() => new Reservation
    {
        Active = false,
        Deleted = false,
        CreatedBy = "Alice",
        CreatedAt = DateTimeOffset.Now,
        StartDate = DateTimeOffset.Now.AddDays(1),
        EndDate = DateTimeOffset.Now.AddDays(2),
        CustomerName = "Alice Doe",
        CustomerContact = "alice@example.com",
        Title = "Birthday Party",
        Comments = "Potrzebuje wiertarkê na 1 dobê",
        Value = 100.0m,
        DuringExecution = true
    };
    //public static NewReservationVm GetNewReservationVm01() => new NewReservationVm
    //{
    //    StartDate = DateTimeOffset.Now.AddDays(1),
    //    EndDate = DateTimeOffset.Now.AddDays(2),
    //    CustomerName = "Alice Doe",
    //    CustomerContact = "alice@example.com",
    //    Title = "Birthday Party",
    //    Comments = "Potrzebuje wiertarkê na 1 dobê"
    //};
}