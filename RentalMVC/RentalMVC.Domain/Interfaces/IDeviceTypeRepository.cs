using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceTypeRepository
{
    Task<int> CreateAsync(DeviceType deviceType, CancellationToken cancellationToken = default);
    IQueryable<DeviceType> GetAllDeviceTypes();
    Task<DeviceType?> GetTypeAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(DeviceType deviceType, CancellationToken cancellationToken = default);
}