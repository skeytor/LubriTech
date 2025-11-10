namespace LubriTech.Persistence.IntegrationTest.Initializers;

internal static class DataInitializer
{
    internal static Task SeedDataAsync(AppDbContext context)
    {
        context.Categories.AddRange(SampleData.Categories);
        context.Brands.AddRange(SampleData.Brands);
        context.Products.AddRange(SampleData.Products);
        return context.SaveChangesAsync();
    }
}