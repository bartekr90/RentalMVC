using Microsoft.EntityFrameworkCore;

namespace RentalMVC.Tests.InfrastructureTests;

public class AddressRepositoryTests
{
    private readonly AddressRepository _sut;
    private readonly Mock<Context> _contextMock = new Mock<Context>();
    private readonly Mock<DbSet<Address>> _addressesMock = new Mock<DbSet<Address>>();

    public AddressRepositoryTests()
    {
        _sut = new AddressRepository(_contextMock.Object);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnAdress_WhenExistsAsync()
    {
        //arrange
        var userId = "creator2";
        int id = 2;
        IQueryable<Address> addresses = GetAddressEntities.AsQueryable();
        var expectedAddress = GetAddressEntities[1];

        // Set up mock
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.Provider).Returns(addresses.Provider);
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.Expression).Returns(addresses.Expression);
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.ElementType).Returns(addresses.ElementType);
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.GetEnumerator()).Returns(addresses.GetEnumerator());
        _contextMock.Setup(c => c.Addresses).Returns(_addressesMock.Object);

        //act
        Address result = await _sut.GetAsync(userId, id);

        //assert
        result.Should().NotBeNull();
        result.CreatorId.Should().Be(userId);
        result.Id.Should().Be(id);
        result.Should().BeEquivalentTo(expectedAddress);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnNull_WhenAddressDoesNotExist()
    {
        // Arrange
        var userId = "234234-23424";
        int id = 1;
        IQueryable<Address> addresses = Enumerable.Empty<Address>().AsQueryable();

        // Set up mock
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.Provider).Returns(addresses.Provider);
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.Expression).Returns(addresses.Expression);
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.ElementType).Returns(addresses.ElementType);
        _addressesMock.As<IQueryable<Address>>().Setup(m => m.GetEnumerator()).Returns(addresses.GetEnumerator());

        _contextMock.Setup(c => c.Addresses).Returns(_addressesMock.Object);

        // Act
        var result = await _sut.GetAsync(userId, id);

        // Assert
        result.Should().BeNull();
    }
}
