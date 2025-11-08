using SharedKernel.Common;
using SharedKernel.ValueObjects;

namespace LubriTech.Domain.Products;

public sealed class Product : IAggregateRoot
{
    private Product() { }
    public Guid Id { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = default!;
    public int BrandId { get; private set; }
    public Brand Brand { get; private set; } = default!;
    public string Name { get; private set; } = string.Empty;
    public Money SellingPrice { get; private set; } = default!;
    public string? Description { get; private set; } = string.Empty;
    public int Stock { get; private set; }
    public Sku Sku { get; private set; } = default!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; private set; }
    public static Product Create(
        int categoryId,
        int brandId,
        string name,
        Money sellingPrice,
        string? description,
        int stock,
        Sku sku)
        => new()
        {
            Id = Guid.NewGuid(),
            CategoryId = categoryId,
            BrandId = brandId,
            Name = name,
            SellingPrice = sellingPrice,
            Description = description,
            Stock = stock,
            Sku = sku,
        };
}
