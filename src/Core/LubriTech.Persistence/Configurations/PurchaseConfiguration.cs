using LubriNet.Persistence.Configurations;
using LubriTech.Domain.Enums;
using LubriTech.Domain.Purchasing;
using LubriTech.Domain.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable(TableNames.Purchases);

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.PurchaseDate)
            .IsRequired();

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                status => status.ToString(),
                value => Enum.Parse<OrderStatus>(value))
            .IsRequired()
            .HasMaxLength(12);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.HasOne<Supplier>()
            .WithMany()
            .HasForeignKey(p => p.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
