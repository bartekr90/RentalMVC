using RentalMVC.Domain.Interfaces;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockIRentalRepository
{
    public static Mock<IRentalRepository> GetMock()
    {
        var mock = new Mock<IRentalRepository>();

        List<Rental> rentals = GetRentalsSample.ToList();

        mock.Setup(m => m.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId id, CancellationToken token) =>
            Task.FromResult(rentals.FirstOrDefault(r => r.Id == id.Value && r.Deleted == false)));

        mock.Setup(m => m.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId id, CancellationToken token) =>
            {
                var rental = rentals.FirstOrDefault(r => r.Id == id.Value && r.Deleted == false);
                return Task.FromResult(rental?.Name);
            });

        return mock;
    }
}
