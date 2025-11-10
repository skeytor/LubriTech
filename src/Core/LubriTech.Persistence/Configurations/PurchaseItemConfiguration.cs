using LubriTech.Domain.Products;
using LubriTech.Domain.Purchasing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItem>
{
    public void Configure(EntityTypeBuilder<PurchaseItem> builder)
    {
        builder.ToTable(TableNames.PurchaseItems);

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Quantity)
            .IsRequired();
        
        builder.ComplexProperty(x => x.UnitPrice, price =>
        {
            price.Property(p => p.Amount)
                .HasColumnName("UnitPrice")
                .IsRequired();

            price.Property(p => p.Currency)
                .HasColumnName("Currency")
                .IsRequired()
                .HasMaxLength(3);
        });
        
        builder.HasOne<Purchase>()
            .WithMany(p => p.Items)
            .HasForeignKey(x => x.PurchaseId);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(x => x.ProductId);
    }
}
