using RentalMVC.Application.Interfaces;

namespace RentalMVC.Tests.ApplicationTests.Mocks;

internal class MockDateTimeProvider
{
    public static Mock<IDateTimeProvider> GetMock()
    {
        var mock = new Mock<IDateTimeProvider>();

        mock.Setup(m => m.Now).Returns(DateTimeOffset.Now);
        mock.Setup(m => m.UtcTime).Returns(DateTimeOffset.UtcNow);

        return mock;
    }
    public static Mock<IDateTimeProvider> GetMock(DateTimeOffset date)
    {
        var mock = new Mock<IDateTimeProvider>();

        mock.Setup(m => m.Now).Returns(date);
        mock.Setup(m => m.UtcTime).Returns(date);

        return mock;
    }
}