namespace LubriTech.Domain.Products;

public sealed class Category
{
    public int Id { get; internal set; }
    public string Name { get; internal set; } = string.Empty;
    public string Description { get; internal set; } = string.Empty;
    public static Category Create(string name, string description)
        => new()
        {
            Description = description,
            Name = name,
        };
}
