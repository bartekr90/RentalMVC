using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Tests;
internal static class SampleDataSet
{
    //stworzy� tablice string[] titles, comments itd do test�w
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
        Comments = "Potrzebuje wiertark� na 1 dob�",
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
    //    Comments = "Potrzebuje wiertark� na 1 dob�"
    //};
}