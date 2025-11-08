namespace LubriTech.Domain.Products;

public sealed class Category
{
    private Category() { }
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public static Category Create(string name, string description)
        => new()
        {
            Description = description,
            Name = name,
            IsActive = true
        };
}
