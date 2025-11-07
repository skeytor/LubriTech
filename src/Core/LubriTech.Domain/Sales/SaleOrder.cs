using LubriTech.Domain.Enums;
using SharedKernel.ValueObjects;

namespace LubriTech.Domain.Sales;

public sealed class SaleOrder
{
    private SaleOrder() { }
    private readonly HashSet<SaleItem> _items = [];
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime SaleDate { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public Money TotalAmount => new(_items.Sum(x => x.UnitPrice.Amount * x.Quantity), "BOB");
    public IReadOnlySet<SaleItem> Items => _items;
    public static SaleOrder Create(Guid customerId) 
        => new()
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            SaleDate = DateTime.UtcNow,
            OrderStatus = OrderStatus.Pending
        };
    public SaleItem AddItem(Guid productId, Money unitPrice, int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
        if (OrderStatus is not OrderStatus.Pending)
        {
            throw new InvalidOperationException("Cannot add items to a non-pending order.");
        }
        SaleItem lineItem = new(productId, Id, unitPrice, quantity);
        _items.Add(lineItem);
        return lineItem;
    }
    public void RemoveItem(SaleItem item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        if (!_items.Remove(item))
        {
            throw new InvalidOperationException("Item not found in the sale order.");
        }
    }
    public void Confirm()
    {
        if (OrderStatus is not OrderStatus.Pending)
        {
            throw new InvalidOperationException("Only pending orders can be confirmed.");
        }
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Cannot confirm an order with no items.");
        }
        OrderStatus = OrderStatus.Completed;
    }
}