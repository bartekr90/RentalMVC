using AutoMapper;
using RentalMVC.Application.Mapping.Mapping;

namespace RentalMVC.Application.ViewModels.Reservation;

public class ReservationForListVm : IMapFrom<RentalMVC.Domain.Model.Entity.Reservation>
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string? Title { get; set; }
    public bool DuringExecution { get; set; }
    public decimal Value { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RentalMVC.Domain.Model.Entity.Reservation, ReservationForListVm>()
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.DuringExecution, opt => opt.MapFrom(src => src.DuringExecution))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
    }
}
