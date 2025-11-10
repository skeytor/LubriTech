using LubriTech.Domain.Products;
using LubriTech.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable(TableNames.SaleItems);

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
                .HasMaxLength(3)
                .IsRequired();
        });

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .IsRequired();

        builder.HasOne<SaleOrder>()
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.SaleId)
            .IsRequired();
    }
}
