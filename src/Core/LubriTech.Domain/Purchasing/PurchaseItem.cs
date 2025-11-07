using SharedKernel.ValueObjects;

namespace LubriTech.Domain.Purchasing;

public sealed class PurchaseItem
{
    internal PurchaseItem() { }
    public int Id { get; private set; }
    public Guid PurchaseId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; private set; }
    internal PurchaseItem(Guid productId, Guid purchaseId, Money unitPrice, int quantity)
    {
        ProductId = productId;
        PurchaseId = purchaseId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}

