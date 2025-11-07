using LubriTech.Domain.Enums;
using SharedKernel.Common;
using SharedKernel.ValueObjects;

namespace LubriTech.Domain.Purchasing;

public sealed class Purchase : IAggregateRoot
{
    private Purchase() { }
    private readonly HashSet<PurchaseItem> _items = [];
    public Guid Id { get; private set; }
    public Guid SupplierId { get; private set; }
    public DateTime PurchaseDate { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; private set; }
    public IReadOnlySet<PurchaseItem> Items => _items;
    public Money TotalAmount => new(_items.Sum(i => i.UnitPrice.Amount * i.Quantity), "BOB");
    public static Purchase Create(Guid supplierId, string currency)
        => new()
        {
            Id = Guid.NewGuid(),
            SupplierId = supplierId,
            CreatedAt = DateTime.UtcNow,
            PurchaseDate = DateTime.UtcNow,
            OrderStatus = OrderStatus.Pending
        };
    public PurchaseItem AddItem(Guid productId, Money unitPrice, int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
        if (OrderStatus is not OrderStatus.Pending)
        {
            throw new InvalidOperationException("Cannot add items to a non-pending order.");
        }
        PurchaseItem lineItem = new(productId, Id, unitPrice, quantity);
        _items.Add(lineItem);
        return lineItem;
    }
    public void RemoveItem(PurchaseItem item)
    {
        if (OrderStatus is not OrderStatus.Pending)
        {
            throw new InvalidOperationException("Cannot remove items from a non-pending order.");
        }
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        if (!_items.Remove(item))
        {
            throw new InvalidOperationException("Item not found in the purchase order.");
        }
    }
}
