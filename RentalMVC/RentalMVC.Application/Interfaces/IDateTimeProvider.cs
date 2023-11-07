namespace RentalMVC.Application.Interfaces;

public interface IDateTimeProvider
{
    public DateTimeOffset Now { get; }
    public DateTimeOffset UtcTime { get; }
}

