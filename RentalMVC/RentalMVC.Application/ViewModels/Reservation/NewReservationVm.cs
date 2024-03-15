using FluentValidation;
using RentalMVC.Application.ViewModels.Common;
using RentalMVC.Application.ViewModels.ReservationPosition;

namespace RentalMVC.Application.ViewModels.Reservation;

public class NewReservationVm : IBaseRentalVm
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public required string ClientName { get; set; }
    public required string RentalName { get; set; }
    public required string Title { get; set; }
    public string? Comments { get; set; }
    public decimal Value { get; set; }
    public int ClientId { get; set; }
    public required ListPositionExtendedVm Positions { get; set; }
    public int RentalId { get; set; }

    public NewReservationVm()
    {
    }

    public NewReservationVm(DateTimeOffset now)
    {
        DateTimeOffset startHour = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Offset).AddHours(1);

        ClientName = "";
        RentalName = "";
        Title = "";
        Comments = "";
        StartDate = startHour;
        EndDate = startHour.AddHours(1);
    }
}

public sealed class NewReservationVmValidator : AbstractValidator<NewReservationVm>
{
    public NewReservationVmValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTimeOffset.Now)
            .LessThanOrEqualTo(x => x.EndDate);

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(x => x.StartDate);

        RuleFor(x => x.ClientName)
            .NotEmpty()
            .Length(0, 100);

        RuleFor(x => x.RentalName)
            .NotEmpty()
            .Length(0, 50);

        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(0, 200);

        RuleFor(x => x.Comments)
            .Length(0, 500);
    }
}