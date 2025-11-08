using LubriTech.Domain.Products;
using SharedKernel.ValueObjects;

namespace LubriTech.Persistence.IntegrationTest.Initializers;

internal static class SampleData
{
    internal static Category[] Categories => [];
    internal static Brand[] Brands => [];
    internal static Product[] Products =>
    [
        Product.Create(
            1, 
            1, 
            "Test Product 1", 
            new Money(100, "USD"), 
            "This is a description", 
            10, 
            Sku.Create("123456789012345")!),
        Product.Create(
            2,
            2,
            "Test Product 2",
            new Money(100, "USD"),
            "This is a description",
            10, 
            Sku.Create("123456789012344")!),
        Product.Create(
            3,
            3,
            "Test Product 3",
            new Money(100, "USD"),
            "This is a description",
            10, 
            Sku.Create("123456789012341")!),
    ];
}
