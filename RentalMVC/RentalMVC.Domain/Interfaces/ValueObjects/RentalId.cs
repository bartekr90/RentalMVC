namespace RentalMVC.Domain.Interfaces.ValueObjects;

public readonly struct RentalId
{
    public int Value { get; }
    public RentalId(int value)
    {
        Value = value <= 0 ? throw new ArgumentException("Invalid rental id") : value;
    }
}