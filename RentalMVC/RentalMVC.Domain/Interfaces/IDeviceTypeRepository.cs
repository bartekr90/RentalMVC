using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Domain.Interfaces;

public interface IDeviceTypeRepository
{
    Task<int> AddAsync(DeviceType type, CancellationToken cancellationToken = default);
    Task UpdateAsync(DeviceType type, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task RemoveAsync(int id, CancellationToken cancellationToken = default);
    Task<IQueryable<DeviceType>> GetDeletedAsync(CancellationToken cancellationToken = default);
    Task<DeviceType> GetByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default);
    Task<IQueryable<DeviceType>> GetAsync(int rentalId, CancellationToken cancellationToken = default);
    Task<IQueryable<DeviceType>> GetAsync(int rentalId, int nodeId, CancellationToken cancellationToken = default);
}