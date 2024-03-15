namespace RentalMVC.Tests.SampleData.ContectDataSample;

internal class ContactDataSample
{
    public static ContactData NewContactData => new()
    {
        Address = NewAddress,
        CreatorId = "",
        Email = "",
        NamePart1 = "",
        NamePart2 = "",
        PhoneNr = ""
    };

    public static ContactData[] GetContactDataSample =>
        new ContactData[]
        {
            new ()
            {
                CreatorId = Users.Lessor_006.GetUserId(),
                Active = true,
                CreatedAt = GetDateTimeSample[0],
                Id = 1,
                Address = NewAddress,
                Email = "Some@email.com",
                NamePart1 = "Nice",
                NamePart2 = "Renral",
                PhoneNr = "123456789",
                AddressId = 1,
            },
            new()
            {
                Address = NewAddress,
                CreatorId = Users.Client_003.GetUserId(),
                Email = "Client@email.com",
                NamePart1 = "Klient",
                NamePart2 = "Klientowski",
                PhoneNr = "778339554",
                CreatedAt = GetDateTimeSample[1],
                Id = 2,
                Active = true,
                AddressId = 2,
            },
            new()
            {
                Address = NewAddress,
                CreatorId = Users.Lessor_007.GetUserId(),
                Email = "SecondLessor07@email.c",
                NamePart1 = "Second",
                NamePart2 = "Lessor",
                PhoneNr = "9097676545",
                CreatedAt = GetDateTimeSample[10],
                Id = 3,
                Active = true,
                AddressId = 3,
            },
            new()
            {
                Address = NewAddress,
                CreatorId = Users.Lessor_007.GetUserId(),
                Email = "SecondRental07@email.c",
                NamePart1 = "Second",
                NamePart2 = "Rental",
                PhoneNr = "9097676545",
                CreatedAt = GetDateTimeSample[10],
                Id = 4,
                Active = true,
                AddressId = 4,
            }
        };
}
