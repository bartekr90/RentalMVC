namespace RentalMVC.Domain.Interfaces.ValueObjects;

public readonly struct DeviceId
{
    public int Value { get; }
    public DeviceId(int value)
    {
        Value = value <= 0 ? throw new ArgumentException("Invalid rental id") : value;
    }
}