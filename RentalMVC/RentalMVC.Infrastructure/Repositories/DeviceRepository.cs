using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly Context _context;

    public DeviceRepository(Context context)
    {
        _context = context;
    }

    public Task<int> AddAsync(Device device, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Device>> GetAsync(int rentalId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Device>> GetAsync(int rentalId, int deviceTypeId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Device> GetByIdAsync(int rentalId, int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Device>> GetDeletedAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Device device, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    //public async Task<int> CreateAsync(Device device, CancellationToken cancellationToken = default)
    //{
    //    _context.Devices.Add(device);
    //    await _context.SaveChangesAsync(cancellationToken);
    //    return device.Id;
    //}

    //public async Task<Device?> GetDeviceAsync(int id, CancellationToken cancellationToken = default) =>
    //    await _context.Devices
    //         .Include(d => d.DeviceType)
    //         .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    //public IQueryable<Device> GetDevicesForType(int deviceTypeId) =>
    //    _context.Devices.Where(d => d.DeviceTypeId == deviceTypeId);

    //public IQueryable<Device> GetAllDevices() =>
    //    _context.Devices;

    //public async Task UpdateAsync(Device device, CancellationToken cancellationToken = default)
    //{
    //    _context.Devices.Update(device);
    //    await _context.SaveChangesAsync(cancellationToken);
    //}

}
