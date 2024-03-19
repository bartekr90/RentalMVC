using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockIDeviceTypeRepository
{
    public static DeviceType? LastUpdatedDeviceType { get; private set; }

    public static Mock<IDeviceTypeRepository> GetMock()
    {
        var mock = new Mock<IDeviceTypeRepository>();

        DeviceType[] deviceTypes = GetDeviceTypesSample;

        mock.Setup(m => m.GetActiveByIdAsync(It.IsAny<DeviceTypeId>(), It.IsAny<CancellationToken>()))
            .Returns((DeviceTypeId id, CancellationToken token) =>
            Task.FromResult(deviceTypes
            .FirstOrDefault(dt => 
            dt.Id == id.Value 
            && dt.Deleted == false
            && dt.Active == true)));

        mock.Setup(m => m.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId rentalId, CancellationToken token) =>
            Task.FromResult(deviceTypes
            .Where(dt => 
            dt.RentalId == rentalId.Value 
            && dt.Deleted == false
            && dt.Active == true)
            .AsEnumerable()));

        mock.Setup(m => m.UpdateDeviceType(It.IsAny<DeviceType>()))
            .Callback((DeviceType device) =>
            {
                LastUpdatedDeviceType = device;
            });

        return mock;
    }
}
