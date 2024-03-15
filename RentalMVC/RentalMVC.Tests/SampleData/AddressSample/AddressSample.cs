namespace RentalMVC.Tests.SampleData.AddressSample;

internal static class AddressSample
{
    public static Address NewAddress => new()
    {
        AddressPartOne = "",
        AddressPartTwo = "",
        City = "",
        CreatorId = "",
        PostalCode = ""
    };

    public static Address[] GetAddressSample =>
        new Address[]
        {
            new() {
                CreatorId = Users.Lessor_006.GetUserId(),
                CreatedAt = GetDateTimeSample[0],
                Id = 1,
                Active = true,
                Deleted = false,
                AddressPartOne = "123 Main St",
                AddressPartTwo = "Apt 4B",
                City = "New York",
                PostalCode = "10001"
            },
            new() {
                CreatorId = Users.Client_003.GetUserId(),
                CreatedAt = GetDateTimeSample[1],
                Id = 2,
                Active = true,
                Deleted = false,
                AddressPartOne = "456 Broadway",
                AddressPartTwo = "Suite 789",
                City = "San Francisco",
                PostalCode = "94103"
            },
            new(){
                CreatorId = Users.Lessor_007.GetUserId(),
                CreatedAt = GetDateTimeSample[10],
                Id = 3,
                Active = true,
                Deleted = false,
                AddressPartOne = "789 Park Ave",
                AddressPartTwo = "Unit 321",
                City = "Chicago",
                PostalCode = "60605"
            },
            new() {
                 CreatorId = Users.Lessor_007.GetUserId(),
                CreatedAt = GetDateTimeSample[10],
                Id = 4,
                Active = true,
                AddressPartOne = "159 Main St",
                AddressPartTwo = "Apt 852",
                City = "Los Angeles",
                PostalCode = "90001"
            },
            new() {
                CreatorId = "creator5",
                CreatedAt = DateTimeOffset.Now,
                Id = 5,
                Active = true,
                Deleted = false,
                AddressPartOne = "741 Broadway",
                AddressPartTwo = "Suite 963",
                City = "Boston",
                PostalCode = "02108"
            },
            new() {
                CreatorId = "creator6",
                CreatedAt = DateTimeOffset.Now,
                Id = 6,
                Active = true,
                Deleted = false,
                AddressPartOne = "852 Park Ave",
                AddressPartTwo = "Unit 147",
                City = "San Diego",
                PostalCode = "92101"
            },
            new() {
                CreatorId = "creator7",
                CreatedAt = DateTimeOffset.Now,
                Id = 7,
                Active = true,
                Deleted = false,
                AddressPartOne = "963 Main St",
                AddressPartTwo = "Apt 258",
                City = "Seattle",
                PostalCode = "98101"
            },
            new() {
                CreatorId = "creator8",
                CreatedAt = DateTimeOffset.Now,
                Id = 8,
                Active = true,
                Deleted = false,
                AddressPartOne = "147 Broadway",
                AddressPartTwo = "Suite 369",
                City = "Austin",
                PostalCode = "73301"
            }

        };

}
