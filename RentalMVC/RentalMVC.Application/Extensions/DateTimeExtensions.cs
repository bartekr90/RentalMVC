namespace RentalMVC.Application.Extensions;

public static class DateTimeExtensions
{
    public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime) =>
         dateTime.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                   ? DateTimeOffset.MinValue
                  : new DateTimeOffset(dateTime);
}

