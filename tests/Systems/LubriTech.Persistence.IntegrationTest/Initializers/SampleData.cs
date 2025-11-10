using LubriTech.Domain.Products;
using SharedKernel.ValueObjects;

namespace LubriTech.Persistence.IntegrationTest.Initializers;

internal static class SampleData
{
    internal static Category[] Categories =>
    [
        Category.Create("Test Category 1", "This is a brief description"),
        Category.Create("Test Category 2", "This is a brief description"),
        Category.Create("Test Category 3", "This is a brief description"),
    ];

    internal static Brand[] Brands =>
    [
        Brand.Create("Test Brand 1"),
        Brand.Create("Test Brand 2"),
        Brand.Create("Test Brand 3"),
    ];
    
    // It assumes that Categories and Brands have been created with the same Ids as here
    internal static Product[] Products =>
    [
        Product.Create(
            1, 
            1, 
            "Test Product 1", 
            new Money(100, "BOB"), 
            "This is a description", 
            10, 
            Sku.Create("123456789012345")!),
        Product.Create(
            2,
            2,
            "Test Product 2",
            new Money(100, "BOB"),
            "This is a description",
            10, 
            Sku.Create("123456789012344")!),
        Product.Create(
            3,
            3,
            "Test Product 3",
            new Money(100, "BOB"),
            "This is a description",
            10, 
            Sku.Create("123456789012341")!),
    ];
}
