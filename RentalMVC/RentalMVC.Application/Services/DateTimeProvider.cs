using RentalMVC.Application.Interfaces;

namespace RentalMVC.Application.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
    public DateTimeOffset UtcTime => DateTimeOffset.UtcNow;
}

