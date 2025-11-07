namespace LubriTech.Domain.Products;
public sealed record Sku
{
    private const int DefaultLength = 15;
    private Sku(string value) => Value = value;
    public string Value { get; init; } = string.Empty;
    public static Sku? Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != DefaultLength)
        {
            return null;
        }
        return new Sku(value);
    }
}
