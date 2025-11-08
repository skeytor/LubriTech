namespace LubriTech.Domain.Products;

public sealed class Brand
{
    private readonly HashSet<Product> _products = [];
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public IReadOnlySet<Product> Products => _products;
    public static Brand Create(string name)
        => new()
        {
            Name = name,
            IsActive = true
        };
}