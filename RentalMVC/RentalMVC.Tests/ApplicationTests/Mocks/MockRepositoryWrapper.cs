using RentalMVC.Domain.Interfaces;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockRepositoryWrapper
{
    public static Mock<IRepositoryWrapper> GetMock()
    {
        var mock = new Mock<IRepositoryWrapper>();

        // Create the mock repositories
        //var addressRepoMock = MockIAddressRepository.GetMock();
        //var clientRepoMock = MockIClientRepository.GetMock();
        var rentalRepoMock = MockIRentalRepository.GetMock();
        var userDetailRepoMock = MockIUserDetailRepository.GetMock();
        //var contactDataRepoMock = MockIContactDataRepository.GetMock();
        var deviceRepoMock = MockIDeviceRepository.GetMock();
        var deviceTypeRepoMock = MockIDeviceTypeRepository.GetMock();
        //var employeeRepoMock = MockIEmployeeRepository.GetMock();
        //var lessorRepoMock = MockILessorRepository.GetMock();
        //var nodeRepoMock = MockINodeRepository.GetMock();
        //var reservationRepoMock = MockIReservationRepository.GetMock();
        //var positionRepoMock = MockIPositionRepository.GetMock();

        // Set up the properties to return the mock repositories
        //mock.Setup(m => m.AddressRepo).Returns(() => addressRepoMock.Object);
        //mock.Setup(m => m.ClientRepo).Returns(() => clientRepoMock.Object);
        mock.Setup(m => m.RentalRepo).Returns(() => rentalRepoMock.Object);
        mock.Setup(m => m.UserDetailRepo).Returns(() => userDetailRepoMock.Object);
        //mock.Setup(m => m.ContactDataRepo).Returns(() => contactDataRepoMock.Object);
        mock.Setup(m => m.DeviceRepo).Returns(() => deviceRepoMock.Object);
        mock.Setup(m => m.DeviceTypeRepo).Returns(() => deviceTypeRepoMock.Object);
        //mock.Setup(m => m.EmployeeRepo).Returns(() => employeeRepoMock.Object);
        //mock.Setup(m => m.LessorRepo).Returns(() => lessorRepoMock.Object);
        //mock.Setup(m => m.NodeRepo).Returns(() => nodeRepoMock.Object);
        //mock.Setup(m => m.ReservationRepo).Returns(() => reservationRepoMock.Object);
        //mock.Setup(m => m.PositionRepo).Returns(() => positionRepoMock.Object);

        // Set up the SaveAsync method
        var cancellationToken = CancellationToken.None;
        mock.Setup(m => m.SaveAsync(cancellationToken)).Returns(Task.FromResult(1));

        return mock;
    }
}