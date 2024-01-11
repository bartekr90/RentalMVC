using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceRepository
{
    Task<int> AddAsync(Device device, CancellationToken cancellationToken = default);
    Task UpdateAsync(Device device, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Device>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<Device> GetByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<Device>> GetAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<IQueryable<Device>> GetAsync(int rentalId, int deviceTypeId, CancellationToken cancellationToken = default);
}