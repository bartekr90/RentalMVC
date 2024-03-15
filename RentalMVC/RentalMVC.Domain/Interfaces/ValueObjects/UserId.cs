namespace RentalMVC.Domain.Interfaces.ValueObjects;

public readonly struct UserId
{
    public string Value { get; }
    public UserId(string value)
    {        
        Value = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Invalid rental id") : value;
    }
}
