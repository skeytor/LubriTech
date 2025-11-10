using LubriTech.Domain.Customers;
using LubriTech.Domain.Enums;
using LubriTech.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class SaleOrderConfiguration : IEntityTypeConfiguration<SaleOrder>
{
    public void Configure(EntityTypeBuilder<SaleOrder> builder)
    {
        builder.ToTable(TableNames.SaleOrders);

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.SaleDate)
            .IsRequired();

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                status => status.ToString(),
                value => Enum.Parse<OrderStatus>(value))
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .IsRequired();
    }
}
