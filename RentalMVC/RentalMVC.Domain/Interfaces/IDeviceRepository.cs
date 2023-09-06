using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceRepository
{
    Task<int> CreateAsync(Device device, CancellationToken cancellationToken = default);
    IQueryable<Device> GetAllDevices();
    Task<Device?> GetDeviceAsync(int id, CancellationToken cancellationToken = default);
    IQueryable<Device> GetDevicesForType(int deviceTypeId);
    Task UpdateAsync(Device device, CancellationToken cancellationToken = default);
}