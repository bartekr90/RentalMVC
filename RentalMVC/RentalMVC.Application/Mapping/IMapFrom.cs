using AutoMapper;

namespace RentalMVC.Application.Mapping.Mapping;

public interface IMapFrom<T>
{
   void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
