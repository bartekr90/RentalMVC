using AutoMapper;
using RentalMVC.Application.Mapping.Mapping;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Application.ViewModels.Reservation;

public class EditReservationVm : IMapFrom<RentalMVC.Domain.Model.Entity.Reservation>
{
    public int Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public required string CustomerName { get; set; }
    public required string CustomerContact { get; set; }
    public required string Title { get; set; }
    public string? Comments { get; set; }
    public virtual ICollection<ReservationPosition> Positions { get; set; } = new List<ReservationPosition>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RentalMVC.Domain.Model.Entity.Reservation, EditReservationVm>()
            .ForMember(e => e.Positions, opt => opt.Ignore());
    }

}
