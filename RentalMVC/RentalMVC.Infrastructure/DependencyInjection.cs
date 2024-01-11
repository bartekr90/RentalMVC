using Microsoft.Extensions.DependencyInjection;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Infrastructure.Repositories;
using ReservationMVC.Domain.Interfaces;

namespace RentalMVC.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDeviceRepository, DeviceRepository>();
        services.AddTransient<IDeviceTypeRepository, DeviceTypeRepository>();
        services.AddTransient<INodeRepository, NodeRepository>();
        services.AddTransient<IPositionRepository, PositionRepository>();
        services.AddTransient<IReservationRepository, ReservationRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IContactDataRepository, ContactDataRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<ILessorRepository, LessorRepository>();
        services.AddTransient<IRentalRepository, RentalRepository>();
        services.AddTransient<IUserDetailRepository, UserDetailRepository>();
        return services;
    }
}
