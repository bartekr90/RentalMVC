using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity.DeviceEntities;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockIDeviceTypeRepository
{
    public static Mock<IDeviceTypeRepository> GetMock()
    {
        var mock = new Mock<IDeviceTypeRepository>();

        List<DeviceType> deviceTypes = GetDeviceTypesSample.ToList();

        mock.Setup(m => m.GetByIdAsync(It.IsAny<DeviceTypeId>(), It.IsAny<CancellationToken>()))
            .Returns((DeviceTypeId id, CancellationToken token) =>
            Task.FromResult(deviceTypes.FirstOrDefault(dt => dt.Id == id.Value && dt.Deleted == false)));

        mock.Setup(m => m.GetTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId rentalId, CancellationToken token) =>
            Task.FromResult(deviceTypes.Where(dt => dt.RentalId == rentalId.Value && dt.Deleted == false)
            .OrderBy(dt => dt.Name).AsEnumerable()));

        return mock;
    }
}
