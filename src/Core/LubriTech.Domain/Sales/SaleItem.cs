using SharedKernel.ValueObjects;

namespace LubriTech.Domain.Sales;

public sealed class SaleItem
{
    private SaleItem() { }
    public int Id { get; private set; }
    public Guid SaleId { get; private set; }
    public Guid ProductId { get; private set; }
    public Money UnitPrice { get; private set; } = default!;
    public int Quantity { get; private set; }
    internal SaleItem(Guid productId, Guid saleId, Money unitPrice, int quantity)
    {
        ProductId = productId;
        SaleId = saleId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}
