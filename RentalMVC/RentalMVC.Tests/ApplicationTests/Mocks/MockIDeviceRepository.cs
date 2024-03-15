using Microsoft.IdentityModel.Tokens;
using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockIDeviceRepository
{
    public static Device? LastCreatedDevice { get; private set; }
    public static Device? LastUpdatedDevice { get; private set; }
    public static Device? LastRemovedDevice { get; private set; }
    public static Device? LastDeletedDevice { get; private set; }
    public static Mock<IDeviceRepository> GetMock()
    {
        var mock = new Mock<IDeviceRepository>();

        Device[] devices = GetDevicesSample;
        Rental[] rentals = GetRentalsSample;
        DeviceType[] deviceTypes = GetDeviceTypesSample;
        ReservationPosition[] positions = GetPositionsSample;


        mock.Setup(m => m.GetListForTypeAsync(It.IsAny<RentalId>(), It.IsAny<DeviceTypeId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId rentalId, DeviceTypeId typeId, CancellationToken token) =>
            Task.FromResult(devices
            .Where(d => d.RentalId == rentalId.Value && d.DeviceTypeId == typeId.Value && d.Deleted == false)
            .AsEnumerable()));

        mock.Setup(m => m.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId rentalId, DeviceId id, CancellationToken token) =>
            Task.FromResult(devices
            .FirstOrDefault(d => d.RentalId == rentalId.Value && d.Id == id.Value && d.Deleted == false)));
        
        mock.Setup(m => m.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()))
        .Returns((RentalId rentalId, DeviceId id, CancellationToken token) =>
        {
            var device = devices
            .FirstOrDefault(d => d.RentalId == rentalId.Value && d.Id == id.Value && d.Deleted == false);

            if (device != null)
            {
                device.DeviceType = deviceTypes.FirstOrDefault(dt => dt.Id == device.DeviceTypeId)!;
                device.Rental = rentals.FirstOrDefault(r => r.Id == device.RentalId)!;
                device.Positions = positions.Where(p => p.DeviceId == device.Id).ToList();
            }
            return Task.FromResult(device);
        });

        mock.Setup(m => m.CreateDevice(It.IsAny<Device>()))
            .Callback((Device device) => 
            { 
                LastCreatedDevice = device; 
            });

        mock.Setup(m => m.UpdateDevice(It.IsAny<Device>()))
            .Callback((Device device) => 
            { 
                LastUpdatedDevice = device; 
            });

        mock.Setup(m => m.RemoveDevice(It.IsAny<Device>()))
            .Callback((Device device) => 
            {
                if (device.Positions.IsNullOrEmpty())
                    device.Positions = null;
                LastRemovedDevice = device; 
            });

        mock.Setup(m => m.DeleteDevice(It.IsAny<Device>()))
            .Callback((Device device) => 
            { 
                LastDeletedDevice = device; 
            });

        return mock;
    }
}

