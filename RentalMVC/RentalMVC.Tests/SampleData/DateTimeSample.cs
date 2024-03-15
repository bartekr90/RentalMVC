namespace RentalMVC.Tests.SampleData;

internal class DateTimeSample
{
    public static DateTimeOffset[] GetDateTimeSample =>
       new DateTimeOffset[20]
       {
            new(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
            new(2021, 3, 1, 0, 0, 0, TimeSpan.Zero),
            new(2021, 5, 1, 0, 0, 0, TimeSpan.Zero),
            new(2021, 7, 1, 0, 0, 0, TimeSpan.Zero),
            new(2021, 9, 1, 0, 0, 0, TimeSpan.Zero),
            new(2021, 11, 1, 0, 0, 0, TimeSpan.Zero),
            new(2022, 1, 1, 0, 0, 0, TimeSpan.Zero),
            new(2022, 3, 1, 0, 0, 0, TimeSpan.Zero),
            new(2022, 5, 1, 0, 0, 0, TimeSpan.Zero),
            new(2022, 7, 1, 0, 0, 0, TimeSpan.Zero),
            new(2022, 9, 1, 0, 0, 0, TimeSpan.Zero),
            new(2022, 11, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 1, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 3, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 5, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 9, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 11, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 12, 1, 0, 0, 0, TimeSpan.Zero),
            new(2023, 12, 31, 0, 0, 0, TimeSpan.Zero)
       };
    public static DateTimeOffset[] GetReserwationDateTimeSample =>
       new DateTimeOffset[6]
       {
            new(2022, 1, 1, 8, 0, 0, TimeSpan.Zero),
            new(2022, 1, 1, 10, 0, 0, TimeSpan.Zero),
            new(2022, 1, 2, 8, 0, 0, TimeSpan.Zero),  
            new(2022, 1, 1, 8, 0, 0, TimeSpan.Zero),
            new(2022, 1, 1, 8, 0, 0, TimeSpan.Zero),
            new(2022, 1, 1, 16, 0, 0, TimeSpan.Zero),            
       };

    public static DateTimeOffset[] GetModifiedDateTimeSample =>
      new DateTimeOffset[20]
        {
            new(2021, 1, 1, 0, 10, 0, TimeSpan.Zero),
            new(2021, 3, 1, 0, 10, 0, TimeSpan.Zero),
            new(2021, 5, 1, 0, 10, 0, TimeSpan.Zero),
            new(2021, 7, 1, 0, 10, 0, TimeSpan.Zero),
            new(2021, 9, 1, 0, 10, 0, TimeSpan.Zero),
            new(2021, 11, 1, 0, 10, 0, TimeSpan.Zero),
            new(2022, 1, 1, 0, 10, 0, TimeSpan.Zero),
            new(2022, 3, 1, 0, 10, 0, TimeSpan.Zero),
            new(2022, 5, 1, 0, 10, 0, TimeSpan.Zero),
            new(2022, 7, 1, 0, 10, 0, TimeSpan.Zero),
            new(2022, 9, 1, 0, 10, 0, TimeSpan.Zero),
            new(2022, 11, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 1, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 3, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 5, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 7, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 9, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 11, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 12, 1, 0, 10, 0, TimeSpan.Zero),
            new(2023, 12, 31, 0, 10, 0, TimeSpan.Zero)
        };
}