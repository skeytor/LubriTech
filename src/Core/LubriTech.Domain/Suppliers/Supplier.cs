using LubriTech.Domain.Purchasing;

namespace LubriTech.Domain.Suppliers;
public sealed class Supplier
{
    private readonly HashSet<Purchase> _purchases = [];
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string ContactName { get; private set; } = string.Empty;
    public string? Phone { get; private set; }
    public string? Email { get; private set; }
    public string? Address { get; private set; }
    public IReadOnlySet<Purchase> Purchases => _purchases;
}

