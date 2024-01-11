namespace RentalMVC.Tests.SampleData;

internal static class AddressSample
{    
    public static Address[] GetAddressEntities =>
        new Address[]
        {
            new Address
            {
                CreatorId = "creator1",
                CreatedAt = DateTimeOffset.Now,
                Id = 1,
                Active = true,
                Deleted = false,
                AddressPartOne = "123 Main St",
                AddressPartTwo = "Apt 4B",
                City = "New York",
                PostalCode = "10001"
            },
            new Address
            {
                CreatorId = "creator2",
                CreatedAt = DateTimeOffset.Now,
                Id = 2,
                Active = true,
                Deleted = false,
                AddressPartOne = "456 Broadway",
                AddressPartTwo = "Suite 789",
                City = "San Francisco",
                PostalCode = "94103"
            },
            new Address
            {
                CreatorId = "creator3",
                CreatedAt = DateTimeOffset.Now,
                Id = 3,
                Active = true,
                Deleted = false,
                AddressPartOne = "789 Park Ave",
                AddressPartTwo = "Unit 321",
                City = "Chicago",
                PostalCode = "60605"
            },
            new Address
            {
                CreatorId = "creator4",
                CreatedAt = DateTimeOffset.Now,
                Id = 4,
                Active = true,
                Deleted = false,
                AddressPartOne = "159 Main St",
                AddressPartTwo = "Apt 852",
                City = "Los Angeles",
                PostalCode = "90001"
            },
            new Address
            {
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
            new Address
            {
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
            new Address
            {
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
            new Address
            {
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
//TODO
//w tablicach bedą przykładowe encje, a w listach będą przykładowe bazy z których pójdą odczyty
//stworzyć tablice string[] titles, comments itd do testów