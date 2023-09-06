using Microsoft.EntityFrameworkCore;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly Context _context;

    public DeviceRepository(Context context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Device device, CancellationToken cancellationToken = default)
    {
        _context.Devices.Add(device);
        await _context.SaveChangesAsync(cancellationToken);
        return device.Id;
    }

    public async Task<Device?> GetDeviceAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Devices
             .Include(d => d.DeviceType)
             .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public IQueryable<Device> GetDevicesForType(int deviceTypeId) =>
        _context.Devices.Where(d => d.DeviceTypeId == deviceTypeId);

    public IQueryable<Device> GetAllDevices() =>
        _context.Devices;

    public async Task UpdateAsync(Device device, CancellationToken cancellationToken = default)
    {
        _context.Devices.Update(device);
        await _context.SaveChangesAsync(cancellationToken);
    }

}
