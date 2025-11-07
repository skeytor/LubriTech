namespace SharedKernel.ValueObjects;

public readonly record struct Money
{
    public Money(decimal amount, string currency)
    {
        if (currency.Length != 3)
        {
            throw new ArgumentException("Currency must be a 3-letter ISO code.", nameof(currency));
        }
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative.");
        }
        Amount = amount;
        Currency = currency;
    }
    public decimal Amount { get; }
    public string Currency { get; } = string.Empty;
}
