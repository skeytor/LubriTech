namespace LubriTech.Domain.Products;

public sealed class Brand
{
    private readonly HashSet<Product> _products = [];
    public int Id { get; internal set; }
    public string Name { get; internal set; } = string.Empty;
    public bool IsActive { get; internal set; }
    public IReadOnlySet<Product> Products => _products;
    public static Brand Create(string name)
        => new()
        {
            Name = name,
            IsActive = true
        };
}