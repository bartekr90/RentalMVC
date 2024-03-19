using RentalMVC.Application.Parameters.DeviceService;
using RentalMVC.Application.Services;
using RentalMVC.Application.ViewModels.Device;
using RentalMVC.Application.ViewModels.DeviceType;
using RentalMVC.Application.ViewModels.ReservationPosition;
using RentalMVC.Domain.Interfaces.ValueObjects;
using RentalMVC.Domain.Model.Entity;
using RentalMVC.Domain.Model.Entity.DeviceEntities;
using RentalMVC.Tests.ApplicationTests.Mocks;
using RentalMVC.Tests.SampleData;

namespace RentalMVC.Tests.ApplicationTests;
public class DeviceServiceTests
{
    public static TheoryData<int, int, DeviceExtendedVm> GetDeviceByIdAsync_WhenDeviceExists =>
       new()
       {
            {1, 1, GetDeviceExtendedVmSample[0]},
            {1, 2, GetDeviceExtendedVmSample[1]},
            {1, 3, GetDeviceExtendedVmSample[2]}
       };

    [Theory]
    [MemberData(nameof(GetDeviceByIdAsync_WhenDeviceExists))]
    public async Task GetDeviceByIdAsync_ShouldReturnDevice_WhenDeviceExists(int rentalId, int deviceId, DeviceExtendedVm expectedDevice)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();

        DeviceService deviceService = new(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        DeviceExtendedVm? result = await deviceService.GetDeviceByIdAsync(new DeviceParams
        {
            DeviceId = deviceId,
            RentalId = rentalId,
        });

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedDevice);
    }

    public static TheoryData<int, int> GetDeviceByIdAsync_WhenDeviceDoesNotExist =>
       new()
       {
            {100000, 1},
            {1, 10000},
            {1, 4},
            {1, 5},
            {1, 778}
       };

    [Theory]
    [MemberData(nameof(GetDeviceByIdAsync_WhenDeviceDoesNotExist))]
    public async Task GetDeviceByIdAsync_ShouldReturnNull_WhenDeviceDoesNotExist(int rentalId, int deviceId)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        var result = await deviceService.GetDeviceByIdAsync(new DeviceParams
        {
            RentalId = rentalId,
            DeviceId = deviceId
        });

        // Assert
        result.Should().BeNull();
    }

    public static TheoryData<AddDeviceParams, Device, DeviceVm, int> AddDeviceAsync_GoodTestData =>
       new()
       {
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[0], RentalId = 1 }, GetDevicesSample[5], GetDeviceVmSample[0], 6},
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[1], RentalId = 1 }, GetDevicesSample[6], GetDeviceVmSample[1], 7},
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[2], RentalId = 1 }, GetDevicesSample[10], GetDeviceVmSample[3], 11}
       };

    [Theory]
    [MemberData(nameof(AddDeviceAsync_GoodTestData))]
    public async Task AddDeviceAsync_ShouldReturnDeviceVm_WhenDeviceIsAddedSuccessfully
        (AddDeviceParams entryParams, Device expectedDomain, DeviceVm expectedVm, int deviceIdInDb)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[3]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        expectedDomain.Rental = GetRentalsSample[0];
        expectedDomain.DeviceType = GetDeviceTypesSample[1];
        expectedDomain.DeviceType.TotalDevices++;
        DeviceTypeId expDeviceTypeId = new(entryParams.ViewModel.DeviceTypeId);
        RentalId expRentalId = new(entryParams.ViewModel.RentalId);

        // Act
        DeviceVm? result = await sut.AddDeviceAsync(entryParams);
        Device savedDeviceInDb = MockIDeviceRepository.LastCreatedDevice!;
        DeviceType savedTypeInDb = MockIDeviceTypeRepository.LastUpdatedDeviceType!;
        result!.Id = deviceIdInDb;

        // Assert
        result.Should().NotBeNull().And.BeEquivalentTo(expectedVm);

        mockRepoWrapper.Verify(r => r.DeviceTypeRepo
        .GetActiveByIdAsync(expDeviceTypeId, It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.RentalRepo
        .GetByIdAsync(expRentalId, It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceTypeRepo
        .UpdateDeviceType(savedTypeInDb), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .CreateDevice(savedDeviceInDb), Times.Once);

        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Once);

        savedDeviceInDb!.Id = deviceIdInDb;
        savedDeviceInDb.Should().BeEquivalentTo(expectedDomain);
        savedTypeInDb.Should().BeEquivalentTo(expectedDomain.DeviceType);
    }

    public static TheoryData<AddDeviceParams> AddDeviceAsync_BadTestData =>
      new()
      {
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[1], RentalId = 0 }},
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[3], RentalId = 1 }},
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[1], RentalId = -1 }},
           { new AddDeviceParams { ViewModel = GetNewDeviceVmSample[1], RentalId = 10000 }},
           { new AddDeviceParams { ViewModel = null!, RentalId = 0 }},
           { null! }
      };

    [Theory]
    [MemberData(nameof(AddDeviceAsync_BadTestData))]

    public async Task AddDeviceAsync_ShouldReturnNull_WhenRentalIdIsDiffrentAndParamsIsNull(AddDeviceParams args)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        DeviceVm? result = await sut.AddDeviceAsync(args);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddDeviceAsync_ShouldReturnNull_WhenRentalIdIsDiffrentForType()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var service = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        var newDeviceVm = new NewDeviceVm
        {
            Name = "Test Device",
            RentalId = 1,
            SerialNr = "123456",
            DeviceTypeId = 3,
            ListOfDeviceTypeVm = new ListDeviceTypeVm(),
            UserId = "asdasd"
        };
        AddDeviceParams entryParams = new() { ViewModel = newDeviceVm, RentalId = 1 };

        // Act
        var result = await service.AddDeviceAsync(entryParams);

        // Assert
        result.Should().BeNull();
    }

    public static TheoryData<string, string> AddDeviceAsync_EmptyStringsTestData =>
      new()
      {
          {"", "userid" },
          {"Name", "" },
          {"", "" },
          {null!, null! }
      };

    [Theory]
    [MemberData(nameof(AddDeviceAsync_EmptyStringsTestData))]

    public async Task AddDeviceAsync_ShouldReturnNull_WhenUserIdIsEmpty(string name, string userId)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var service = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        var newDeviceVm = new NewDeviceVm
        {
            Name = name,
            RentalId = 1,
            SerialNr = "123456",
            DeviceTypeId = 1,
            ListOfDeviceTypeVm = new ListDeviceTypeVm(),
            UserId = userId
        };
        AddDeviceParams entryParams = new() { ViewModel = newDeviceVm, RentalId = 1 };

        // Act
        var result = await service.AddDeviceAsync(entryParams);

        // Assert
        result.Should().BeNull();
    }

    public static TheoryData<AddDeviceParams> AddDeviceAsync_ExceptionTestData =>
    new()
    {
           { new AddDeviceParams { ViewModel = GetNewNewDeviceVm, RentalId = 1 } },
           { new AddDeviceParams { ViewModel = GetNewDeviceVmTest2, RentalId = 1 } }
    };

    [Theory]
    [MemberData(nameof(AddDeviceAsync_ExceptionTestData))]
    public async Task AddDeviceAsync_ShouldThrowArgumentException_WhenInvalidArgumentProvided(AddDeviceParams args)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => sut.AddDeviceAsync(args));
    }

    public static TheoryData<DeleteDeviceParams> DeleteDeviceAsync_BadTestData =>
      new()
      {
          {new DeleteDeviceParams { UserId = "", ViewModel = GetDeviceExtendedVmSample[5], RentalId = 1 } },
          {new DeleteDeviceParams { UserId = null!, ViewModel = GetDeviceExtendedVmSample[5], RentalId = 1 } },
          {new DeleteDeviceParams { UserId = "Some", ViewModel = GetDeviceExtendedVmSample[5], RentalId = 12 } },
          {new DeleteDeviceParams { UserId = "Some", ViewModel = GetNewDeviceExtendedVm, RentalId = 1 } },
          {null! }
      };

    [Theory]
    [MemberData(nameof(DeleteDeviceAsync_BadTestData))]
    public async Task DeleteDeviceAsync_ShouldReturnNull_ForBadData
        (DeleteDeviceParams args)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        var result = await sut.DeleteDeviceAsync(args);

        // Assert
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r.DeviceRepo
            .GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r.DeviceRepo
            .DeleteDevice(It.IsAny<Device>()), Times.Never);
    }

    public static TheoryData<DeleteDeviceParams> DeleteDeviceAsync_WhenDeviceTypeNotFound =>
      new()
      {
          {new DeleteDeviceParams { UserId = "Some", ViewModel = GetBadDeviceExtendedVmSample[0], RentalId = 1 } },
          {new DeleteDeviceParams { UserId = "Some", ViewModel = GetBadDeviceExtendedVmSample[1], RentalId = 1223 } },
          {new DeleteDeviceParams { UserId = "Some", ViewModel = GetBadDeviceExtendedVmSample[2], RentalId = 2 } },
      };

    [Theory]
    [MemberData(nameof(DeleteDeviceAsync_WhenDeviceTypeNotFound))]
    public async Task DeleteDeviceAsync_ShouldReturnNull_WhenDeviceNotFound
        (DeleteDeviceParams args)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        var result = await sut.DeleteDeviceAsync(args);

        // Assert
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r.DeviceRepo
            .DeleteDevice(It.IsAny<Device>()), Times.Never);
        mockRepoWrapper.Verify(r => r.DeviceRepo
            .GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    public static TheoryData<DeleteDeviceParams, Device, DateTimeOffset> DeleteDeviceAsync_GoodTestData =>
       new()
       {
           { new DeleteDeviceParams { ViewModel = GetDeviceExtendedVmSample[3], UserId = Users.Employee_008.GetUserId(), RentalId = 1 },
               GetDeletedDeviceSample[0],
               GetDateTimeSample[6]
           },
           { new DeleteDeviceParams { ViewModel = GetDeviceExtendedVmSample[4], UserId = Users.Employee_008.GetUserId(), RentalId = 1 },
               GetDeletedDeviceSample[1],
               GetDateTimeSample[5]
           },
           { new DeleteDeviceParams { ViewModel = GetDeviceExtendedVmSample[5], UserId = Users.Lessor_006.GetUserId(), RentalId = 1 },
               GetDeletedDeviceSample[2],
               GetDateTimeSample[5]
           }
       };

    [Theory]
    [MemberData(nameof(DeleteDeviceAsync_GoodTestData))]

    public async Task DeleteDeviceAsync_ShouldReturnDeviceId_WhenDeviceIsDeleted
        (DeleteDeviceParams args, Device expectedSaved, DateTimeOffset expectedDateTime)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(expectedDateTime);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        expectedSaved.DeviceType = GetDeviceTypesSample.FirstOrDefault(t => t.Id == expectedSaved.DeviceTypeId);
        expectedSaved.DeviceType.TotalDevices--;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        expectedSaved.Rental = GetRentalsSample[0];

        // Act
        var result = await sut.DeleteDeviceAsync(args);
        Device? savedInDb = MockIDeviceRepository.LastDeletedDevice;
        DeviceType? savedTypeInDb = MockIDeviceTypeRepository.LastUpdatedDeviceType;


        // Assert
        result.Should().NotBeNull().And.Be(1);
        savedInDb.Should().BeEquivalentTo(expectedSaved);
        savedTypeInDb.Should().BeEquivalentTo(expectedSaved.DeviceType);

        mockRepoWrapper.Verify(r => r.DeviceTypeRepo
        .UpdateDeviceType(savedTypeInDb!), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .DeleteDevice(savedInDb!), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .DeleteDevice(It.IsAny<Device>()), Times.Once);
    }

    [Fact]
    public async Task DeleteDeviceAsync_ShouldThrowArgumentException_WhenRentalIdIsLessThanOrEqualToZero()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[3]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        DeleteDeviceParams args = new()
        {
            ViewModel = GetBadDeviceExtendedVmSample[3],
            RentalId = 0,
            UserId = "333"
        };

        // Act
        Func<Task> act = async () => await sut.DeleteDeviceAsync(args);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task DeleteDeviceAsync_ShouldThrowArgumentException_WhenTotalNumberIsToLow()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[3]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        DeviceExtendedVm vm = new()
        {
            CreatorId = Users.Lessor_006.GetUserId(),
            CreatedAt = GetDateTimeSample[0],
            Id = 18,
            Active = true,
            Name = "Sprzęt z grupy która nie ma urzadzeń",
            DeviceTypeId = 3,
            RentalId = 2,
            SerialNr = "TO-1234",
            IsAvailable = false,
            RentalName = "SecondRental",
            TypeName = "Some broke stuff",
            IsOnPositions = true,
        };

        DeleteDeviceParams args = new()
        {
            ViewModel = vm,
            RentalId = 2,
            UserId = Users.Lessor_006.GetUserId()
        };

        // Act
        Func<Task> act = async () => await sut.DeleteDeviceAsync(args);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Invalid TotalDevices of type with id: 3");
    }

    [Fact]
    public async Task DeleteDeviceAsync_ShouldThrowArgumentException_WhenUserIdIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[3]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        DeleteDeviceParams args = new()
        {
            ViewModel = GetBadDeviceExtendedVmSample[4],
            RentalId = 1,
            UserId = "333"
        };

        // Act
        Func<Task> act = async () => await sut.DeleteDeviceAsync(args);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }

    public static TheoryData<DeviceParams, EditDeviceVm, DeviceTypeVm, ListPositionVm> GetDeviceForEditAsync_GoodTestData =>
        new()
        {
            { new DeviceParams { DeviceId = 12, RentalId = 2 },
                GetEditDeviceVmSample[0],
                GetDeviceTypeVmSampleWithRentalId2[0],
                GetListPositionVmByDeviceId_12},
            { new DeviceParams { DeviceId = 13, RentalId = 2 },
                GetEditDeviceVmSample[1],
                GetDeviceTypeVmSampleWithRentalId2[0],
                GetListPositionVmByDeviceId_13},
            { new DeviceParams { DeviceId = 14, RentalId = 2 },
                GetEditDeviceVmSample[2],
                GetDeviceTypeVmSampleWithRentalId2[0],
                GetListPositionVmByDeviceId_14}
        };

    [Theory]
    [MemberData(nameof(GetDeviceForEditAsync_GoodTestData))]
    public async Task GetDeviceForEditAsync_ShouldReturnEditVm_WhenValidDeviceParams
        (DeviceParams deviceParams, EditDeviceVm expectedVm, DeviceTypeVm expectedTypeVm, ListPositionVm expectedPositionsVm)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        expectedVm.PositionsVm = expectedPositionsVm;
        expectedVm.DeviceTypeVm = expectedTypeVm;
        expectedVm.TypesListVm = GetListDeviceTypeVmSampleByRental[0];

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(deviceParams);

        // Assert       
        result.Should().NotBeNull().And.BeEquivalentTo(expectedVm);
        result!.TypesListVm.Should().NotBeNull();
        result.PositionsVm.Should().NotBeNull();
        result.DeviceTypeVm.Should().NotBeNull();

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetByIdExtendedAsync(new RentalId(deviceParams.RentalId), new DeviceId(deviceParams.DeviceId), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(new RentalId(deviceParams.RentalId), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(new RentalId(deviceParams.RentalId), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceParamsIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(null!);

        // Assert       
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r
       .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }
    public static TheoryData<DeviceParams> GetDeviceForEditAsync_BadTestData =>
            new()
            {
            { new DeviceParams { DeviceId = 15, RentalId = 2 }},
            { new DeviceParams { DeviceId = 16, RentalId = 2 }},
            };

    [Theory]
    [MemberData(nameof(GetDeviceForEditAsync_BadTestData))]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceIsUnavailable(DeviceParams deviceParams)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(deviceParams);

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenRentalIdIsBad()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 12, RentalId = 24 });

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }
    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceIdIsBad()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 1234, RentalId = 2 });

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceAndRentalNotMatch()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 12, RentalId = 1 });

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceTypeRepoFails()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);


        mockRepoWrapper.Setup(r => r.DeviceTypeRepo
        .GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());

        // Act
        Exception? exception = null;
        try
        {
            EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 12, RentalId = 2 });
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        // Assert       
        exception.Should().NotBeNull();

        mockRepoWrapper.Verify(r => r
      .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenRentalRepoFails()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);


        mockRepoWrapper.Setup(r => r.RentalRepo
        .GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception());

        // Act
        Exception? exception = null;
        try
        {
            EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 12, RentalId = 2 });
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        // Assert       
        exception.Should().NotBeNull();

        mockRepoWrapper.Verify(r => r
      .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceIsUnavailable_v2()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        mockRepoWrapper.Setup(r => r.DeviceRepo
        .GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Device)null!);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 12, RentalId = 2 });

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
      .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenRentalNameIsNullOrEmpty()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        mockRepoWrapper.Setup(r => r.RentalRepo
        .GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(string.Empty);

        // Act
        EditDeviceVm? result = await sut.GetDeviceForEditAsync(new DeviceParams { DeviceId = 12, RentalId = 2 });

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
      .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }
    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenDeviceTypeIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        var deviceParams = new DeviceParams { DeviceId = 12, RentalId = 2 };

        mockRepoWrapper.Setup(r => r.DeviceRepo
        .GetByIdExtendedAsync(deviceParams.GetRentalId, deviceParams.GetDeviceId, deviceParams.Token))
            .ReturnsAsync(NewDevice);

        // Act
        var result = await sut.GetDeviceForEditAsync(deviceParams);

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
      .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task GetDeviceForEditAsync_ShouldReturnNull_WhenTypesListIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(GetDateTimeSample[13]);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        var deviceParams = new DeviceParams { DeviceId = 12, RentalId = 2 };

        mockRepoWrapper.Setup(r => r.DeviceTypeRepo
            .GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<DeviceType>)null!);

        // Act
        var result = await sut.GetDeviceForEditAsync(deviceParams);

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
      .DeviceRepo.GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .RentalRepo.GetNameByIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    public static TheoryData<DeviceListParams, ListDeviceVm> GetDevicesListAsync_GoodTestData =>
    new()
    {
        { new DeviceListParams { RentalId = 1, TypeId = 1 }, ListDeviceVmSampleWithRentalId1[0] },
        { new DeviceListParams { RentalId = 1, TypeId = 2 }, ListDeviceVmSampleWithRentalId1[1] },
        { new DeviceListParams { RentalId = 2, TypeId = 5 }, ListDeviceVmSampleWithRentalId2[0] },
        { new DeviceListParams { RentalId = 2, TypeId = 4 }, ListDeviceVmSampleWithRentalId2[1] },
    };

    [Theory]
    [MemberData(nameof(GetDevicesListAsync_GoodTestData))]
    public async Task GetDevicesListAsync_ShouldReturnListDeviceVm_WhenValidDeviceListParams
        (DeviceListParams deviceListParams, ListDeviceVm expectedVm)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        ListDeviceVm? result = await sut.GetAllDevicesListAsync(deviceListParams);

        // Assert       
        result.Should().NotBeNull().And.BeEquivalentTo(expectedVm);

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetListForTypeAsync(new RentalId(deviceListParams.RentalId), new DeviceTypeId(deviceListParams.TypeId), It.IsAny<CancellationToken>()), Times.Once);
    }

    public static TheoryData<DeviceListParams, ListDeviceVm> GetDevicesListAsync_BadTestData =>
    new()
    {
        { new DeviceListParams { RentalId = 110, TypeId = 1 }, null! },
        { new DeviceListParams { RentalId = 1, TypeId = 110 }, null! },
        { new DeviceListParams { RentalId = 110, TypeId = 110 }, null! },
    };

    [Theory]
    [MemberData(nameof(GetDevicesListAsync_BadTestData))]
    public async Task GetAllDevicesListAsync_ShouldReturnNull_WhenInvalidDeviceListParams
        (DeviceListParams deviceListParams, ListDeviceVm expectedVm)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        ListDeviceVm? result = await sut.GetAllDevicesListAsync(deviceListParams);

        // Assert       
        result.Should().Be(expectedVm);

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetListForTypeAsync(new RentalId(deviceListParams.RentalId), new DeviceTypeId(deviceListParams.TypeId), It.IsAny<CancellationToken>()), Times.Once);
    }

    public static TheoryData<DeviceListParams> GetDevicesListAsync_BadTestData_v2 =>
    new()
    {
        { new DeviceListParams { RentalId = 0, TypeId = 1 }},
        { new DeviceListParams { RentalId = 1, TypeId = 0 }},
        { new DeviceListParams { RentalId = 0, TypeId = 0 }},
    };

    [Theory]
    [MemberData(nameof(GetDevicesListAsync_BadTestData_v2))]
    public async Task GetAllDevicesListAsync_ShouldThrowArgumentException_WhenInvalidDeviceListParams
        (DeviceListParams deviceListParams)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        Func<Task> act = async () => await sut.GetAllDevicesListAsync(deviceListParams);

        // Assert       
        await act.Should().ThrowAsync<ArgumentException>();

        mockRepoWrapper.Verify(r => r
        .DeviceRepo.GetListForTypeAsync(It.IsAny<RentalId>(), It.IsAny<DeviceTypeId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<NewDeviceParams, NewDeviceVm> GetNewDeviceAsync_GoodTestData =>
    new()
    {
        { new NewDeviceParams { RentalId = 2 }, GetExpectedNewDeviceVmSample[0] },
        { new NewDeviceParams { RentalId = 1 }, GetExpectedNewDeviceVmSample[1] },
        { new NewDeviceParams { RentalId = 30 }, null!},
    };

    [Theory]
    [MemberData(nameof(GetNewDeviceAsync_GoodTestData))]
    public async Task GetNewDeviceAsync_ShouldReturnNewDeviceVm_WhenValidNewDeviceParams(NewDeviceParams newDeviceParams, NewDeviceVm expectedVm)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        NewDeviceVm? result = await sut.GetNewDeviceAsync(newDeviceParams);

        // Assert       
        result.Should().BeEquivalentTo(expectedVm);

        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(newDeviceParams.GetRentalId, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetNewDeviceAsync_ShouldReturnNull_WhenNewDeviceParamsIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        NewDeviceVm? result = await sut.GetNewDeviceAsync(null!);

        // Assert       
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<NewDeviceParams> GetNewDeviceAsync_BadTestData =>
    new()
    {
        { new NewDeviceParams { RentalId = 0 }},
        { new NewDeviceParams { RentalId = -1 }},
    };

    [Theory]
    [MemberData(nameof(GetNewDeviceAsync_BadTestData))]
    public async Task GetNewDeviceAsync_ShouldReturnException_WhenRentalBelowZero(NewDeviceParams newDeviceParams)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        Func<Task> act = async () => await sut.GetNewDeviceAsync(newDeviceParams);

        // Assert       
        await act.Should().ThrowAsync<ArgumentException>();

        mockRepoWrapper.Verify(r => r
        .DeviceTypeRepo.GetActiveTypesListByRentalIdAsync(It.IsAny<RentalId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateDeviceAsync_ShouldReturnNull_WhenParamsIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        var result = await deviceService.UpdateDeviceAsync(null!);

        // Assert
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r
            .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.UpdateDevice(It.IsAny<Device>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateDeviceAsync_ShouldReturnNull_WhenViewModelIsNull()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        var updateDeviceParams = new UpdateDeviceParams
        {
            ViewModel = null!,
            UserId = "some string",
            RentalId = 1,
            Token = CancellationToken.None
        };

        // Act
        var result = await deviceService.UpdateDeviceAsync(updateDeviceParams);

        // Assert
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r
            .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.UpdateDevice(It.IsAny<Device>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<UpdateDeviceParams> UpdateDeviceAsync_BadParams =>
    new()
    {
        new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[0], RentalId = 2, UserId = null! },
        new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[0], RentalId = 2, UserId = "" }
    };

    [Theory]
    [MemberData(nameof(UpdateDeviceAsync_BadParams))]
    public async Task UpdateDeviceAsync_ShouldReturnNull_WhenUserIdIsNull(UpdateDeviceParams updateDeviceParams)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        var result = await deviceService.UpdateDeviceAsync(updateDeviceParams);

        // Assert
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r
            .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.UpdateDevice(It.IsAny<Device>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateDeviceAsync_ShouldReturnNull_WhenRentalIdDoesNotMatchViewModelRentalId()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        var viewModel = GetEditDeviceVmSample[0];
        var updateDeviceParams = new UpdateDeviceParams
        {
            ViewModel = viewModel,
            UserId = "some string",
            RentalId = viewModel.RentalId + 1,
            Token = CancellationToken.None
        };

        // Act
        var result = await deviceService.UpdateDeviceAsync(updateDeviceParams);

        // Assert
        result.Should().BeNull();
        mockRepoWrapper.Verify(r => r
            .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.UpdateDevice(It.IsAny<Device>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<int, int> UpdateDeviceAsync_BadTestData =>
    new()
    {
       {0, 1},
       {1, 0},
       {-10, 1},
       {1, -10}
    };

    [Theory]
    [MemberData(nameof(UpdateDeviceAsync_BadTestData))]
    public async Task UpdateDeviceAsync_ShouldThrowArgumentException_WhenIdAndRentalIdAreZeroOrBelow(int rentalId, int deviceid)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        var viewModel = GetEditDeviceVmSample[0];
        viewModel.Id = deviceid;
        viewModel.RentalId = rentalId;
        var updateDeviceParams = new UpdateDeviceParams
        {
            ViewModel = viewModel,
            UserId = "some string",
            RentalId = rentalId,
            Token = CancellationToken.None
        };

        // Act
        Func<Task> act = async () => await deviceService.UpdateDeviceAsync(updateDeviceParams);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        mockRepoWrapper.Verify(r => r
            .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.UpdateDevice(It.IsAny<Device>()), Times.Never);
        mockRepoWrapper.Verify(r => r
            .DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<UpdateDeviceParams, Device, DeviceVm, DateTimeOffset> UpdateDeviceAsync_ValidData =>
    new()
    {
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[0], RentalId = 2, UserId = Users.Lessor_007.GetUserId() },
            GetModifiedDeviceSample[0],
            GetDeviceVmSampleAsReturnFromEdit[0],
            GetModifiedDateTimeSample[14]
        },
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[1], RentalId = 2, UserId = Users.Lessor_007.GetUserId() },
            GetModifiedDeviceSample[1],
            GetDeviceVmSampleAsReturnFromEdit[1],
            GetModifiedDateTimeSample[15]
        },
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[2], RentalId = 2, UserId = Users.Lessor_007.GetUserId() },
            GetModifiedDeviceSample[2],
            GetDeviceVmSampleAsReturnFromEdit[2],
            GetModifiedDateTimeSample[16]
        },
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[3], RentalId = 1, UserId = Users.Employee_008.GetUserId() },
            GetModifiedDeviceSample[3],
            GetDeviceVmSampleAsReturnFromEdit[3],
            GetModifiedDateTimeSample[17]
        },
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[4], RentalId = 1, UserId = Users.Employee_008.GetUserId() },
            GetModifiedDeviceSample[4],
            GetDeviceVmSampleAsReturnFromEdit[4],
            GetModifiedDateTimeSample[18]
        },
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[5], RentalId = 1, UserId = Users.Employee_008.GetUserId() },
            GetModifiedDeviceSample[5],
            GetDeviceVmSampleAsReturnFromEdit[5],
            GetModifiedDateTimeSample[19]
        },
        { new UpdateDeviceParams { ViewModel = GetEditDeviceVmSample[6], RentalId = 1, UserId = Users.Employee_008.GetUserId() },
            GetModifiedDeviceSample[6],
            GetDeviceVmSampleAsReturnFromEdit[6],
            GetModifiedDateTimeSample[19]
        }
    };

    [Theory]
    [MemberData(nameof(UpdateDeviceAsync_ValidData))]
    public async Task UpdateDeviceAsync_ShouldUpdateDevice_WhenDataIsValid
        (UpdateDeviceParams entryParams, Device expectedDomain, DeviceVm expectedVm, DateTimeOffset dateTime)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock(dateTime);
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        DeviceVm? result = await sut.UpdateDeviceAsync(entryParams);
        Device savedInDb = MockIDeviceRepository.LastUpdatedDevice!;

        // Assert
        result.Should().NotBeNull().And.BeEquivalentTo(expectedVm);

        mockRepoWrapper.Verify(r => r.DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Once);
        mockRepoWrapper.Verify(r => r.DeviceRepo.UpdateDevice(It.IsAny<Device>()), Times.Once);
        mockRepoWrapper.Verify(r => r.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);

        savedInDb.Should().BeEquivalentTo(expectedDomain);
    }

    public static TheoryData<int, int> RemoveDeviceAsync_BadTestData =>
    new()
    {
       {0, 1},
       {1, 0},
       {-10, 1},
       {1, -10}
    };

    [Theory]
    [MemberData(nameof(RemoveDeviceAsync_BadTestData))]
    public async Task RemoveDeviceAsync_ShouldThrowArgumentException_WhenIdAndRentalIdAreZeroOrBelow(int rentalId, int deviceid)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var deviceService = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        var viewModel = GetDeviceExtendedVmSample[0];
        viewModel.Id = deviceid;
        viewModel.RentalId = rentalId;
        var entryParams = new RemoveDeviceParams
        {
            ViewModel = viewModel,
            RentalId = rentalId
        };

        // Act
        Func<Task> act = async () => await deviceService.RemoveDeviceAsync(entryParams);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .RemoveDevice(It.IsAny<Device>()), Times.Never);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<RemoveDeviceParams, Device, DeviceType, Rental> RemoveDeviceAsync_ValidData =>
    new()
    {
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[0], RentalId = 1 },
            GetDevicesSample[0],
            GetDeviceTypesSample[0],
            GetRentalsSample[0]  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[1], RentalId = 1 },
            GetDevicesSample[1],
            GetDeviceTypesSample[0],
            GetRentalsSample[0]  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[2], RentalId = 1 },
            GetDevicesSample[2],
            GetDeviceTypesSample[0],
            GetRentalsSample[0]  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[3], RentalId = 1 },
            GetDevicesSample[7],
            GetDeviceTypesSample[0],
            GetRentalsSample[0]  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[4], RentalId = 1 },
            GetDevicesSample[8],
            GetDeviceTypesSample[0],
            GetRentalsSample[0]  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[5], RentalId = 1 },
            GetDevicesSample[9],
            GetDeviceTypesSample[1],
            GetRentalsSample[0]  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[11], RentalId = 2 },
            GetDevicesSample[16],
            GetDeviceTypesSample[4],
            GetRentalsSample[1]  },
    };

    [Theory]
    [MemberData(nameof(RemoveDeviceAsync_ValidData))]
    public async Task RemoveDeviceAsync_ShouldRemoveDevice_WhenDataIsValid
        (RemoveDeviceParams entryParams, Device expectedDomain, DeviceType type, Rental rental)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        type.TotalDevices--;
        expectedDomain.DeviceType = type;
        expectedDomain.Rental = rental;
        RentalId rentalId = new(entryParams.ViewModel.RentalId);
        DeviceId deviceId = new(entryParams.ViewModel.Id);

        // Act
        int? result = await sut.RemoveDeviceAsync(entryParams);
        Device savedInDb = MockIDeviceRepository.LastRemovedDevice!;
        DeviceType? savedUpdatedType = MockIDeviceTypeRepository.LastUpdatedDeviceType;

        // Assert
        result.Should().Be(1);
        savedInDb.Should().BeEquivalentTo(expectedDomain);
        savedUpdatedType.Should().BeEquivalentTo(type);

        mockRepoWrapper.Verify(r => r.DeviceTypeRepo
        .UpdateDeviceType(savedInDb.DeviceType), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(rentalId, deviceId, It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .RemoveDevice(savedInDb), Times.Once);

        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
    public static TheoryData<RemoveDeviceParams, Device> RemoveDeviceAsync_InvalidData =>
    new()
    {
        { null!, GetDevicesSample[0]  },
        { new RemoveDeviceParams { ViewModel = null!, RentalId = 1 }, GetDevicesSample[0]},
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[1], RentalId = 100 }, GetDevicesSample[1]},
    };

    [Theory]
    [MemberData(nameof(RemoveDeviceAsync_InvalidData))]
    public async Task RemoveDeviceAsync_ShouldReturnNull_WhenDataIsInvalid
        (RemoveDeviceParams entryParams, Device expectedDomain)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        // Act
        int? result = await sut.RemoveDeviceAsync(entryParams);

        // Assert
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()), Times.Never);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .RemoveDevice(expectedDomain), Times.Never);

        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);

    }

    [Fact]
    public async Task RemoveDeviceAsync_ShouldReturnNull_WhenDeviceDontExist()
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        var viewModel = GetDeviceExtendedVmSample[0];
        viewModel.Id = 100;
        var entryParams = new RemoveDeviceParams
        {
            ViewModel = viewModel,
            RentalId = 1
        };

        RentalId rentalId = new(entryParams.ViewModel.RentalId);
        DeviceId deviceId = new(entryParams.ViewModel.Id);

        // Act
        int? result = await sut.RemoveDeviceAsync(entryParams);

        // Assert
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(rentalId, deviceId, It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .RemoveDevice(It.IsAny<Device>()), Times.Never);

        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task RemoveDeviceAsync_ShouldReturnNull_WhenDeviceTypeIsNull()
    {
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);
        var devices = GetDevicesSample;
        var entryParams = new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[0], RentalId = 1 };
        RentalId rentalId = new(entryParams.ViewModel.RentalId);
        DeviceId deviceId = new(entryParams.ViewModel.Id);

        mockRepoWrapper.Setup(r => r.DeviceRepo.GetByIdAsync(It.IsAny<RentalId>(), It.IsAny<DeviceId>(), It.IsAny<CancellationToken>()))
            .Returns((RentalId rentalId, DeviceId id, CancellationToken token) =>
            Task.FromResult(devices
            .FirstOrDefault(d =>
            d.RentalId == rentalId.Value
            && d.Id == id.Value
            && d.Deleted == false)));

        // Act
        int? result = await sut.RemoveDeviceAsync(entryParams);

        // Assert
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(rentalId, deviceId, It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .RemoveDevice(It.IsAny<Device>()), Times.Never);

        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    public static TheoryData<RemoveDeviceParams> RemoveDeviceAsync_HasPositions =>
    new()
    {
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[6], RentalId = 2 }  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[7], RentalId = 2 }  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[8], RentalId = 2 }  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[9], RentalId = 2 }  },
        { new RemoveDeviceParams { ViewModel = GetDeviceExtendedVmSample[10], RentalId = 2 }  },
    };

    [Theory]
    [MemberData(nameof(RemoveDeviceAsync_HasPositions))]
    public async Task RemoveDeviceAsync_ShouldReturnNull_WhenDeviceHasPositions(RemoveDeviceParams entryParams)
    {
        // Arrange
        var mockRepoWrapper = MockRepositoryWrapper.GetMock();
        var mockDateTimeProvider = MockDateTimeProvider.GetMock();
        var sut = new DeviceService(mockRepoWrapper.Object, mockDateTimeProvider.Object);

        RentalId rentalId = new(entryParams.ViewModel.RentalId);
        DeviceId deviceId = new(entryParams.ViewModel.Id);

        // Act
        int? result = await sut.RemoveDeviceAsync(entryParams);

        // Assert
        result.Should().BeNull();

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .GetByIdExtendedAsync(rentalId, deviceId, It.IsAny<CancellationToken>()), Times.Once);

        mockRepoWrapper.Verify(r => r.DeviceRepo
        .RemoveDevice(It.IsAny<Device>()), Times.Never);

        mockRepoWrapper.Verify(r => r
        .SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

}
