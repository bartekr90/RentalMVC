using AutoMapper;
using FluentValidation;
using RentalMVC.Application.Mapping.Mapping;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Application.ViewModels.Reservation;

public class NewReservationVm : IMapFrom<RentalMVC.Domain.Model.Entity.Reservation>
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerContact { get; set; }
    public string? Title { get; set; }
    public string? Comments { get; set; }
    public virtual ICollection<ReservationPosition>? Positions { get; set; }

    public NewReservationVm()
    {        
    }

    public NewReservationVm(DateTimeOffset now)
    {
        DateTimeOffset startHour = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, 0, 0, now.Offset).AddHours(1);
        
        CustomerContact = "";
        CustomerName = "";
        Title = "";
        Comments = "";
        StartDate = startHour;
        EndDate = startHour.AddHours(1);
    }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewReservationVm, RentalMVC.Domain.Model.Entity.Reservation>()
            .ForMember(e => e.Positions, opt => opt.Ignore());
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

        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .Length(0, 100);

        RuleFor(x => x.CustomerContact)
            .NotEmpty()
            .Length(0, 50);

        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(0, 200);

        RuleFor(x => x.Comments)
            .Length(0, 500);
    }
}