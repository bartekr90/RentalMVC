using Microsoft.Extensions.DependencyInjection;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Infrastructure.Repositories;

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
        return services;
    }
}
