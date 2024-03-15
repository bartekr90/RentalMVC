namespace RentalMVC.Domain.Interfaces.ValueObjects;

public readonly struct DeviceTypeId
{
    public int Value { get; }
    public DeviceTypeId(int value)
    {
        Value = value <= 0 ? throw new ArgumentException("Invalid rental id") : value;
    }
}