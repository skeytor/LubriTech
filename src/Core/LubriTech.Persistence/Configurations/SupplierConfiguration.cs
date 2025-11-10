using LubriTech.Domain.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable(TableNames.Suppliers);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.ContactName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Phone)
            .IsRequired(false)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(x => x.Address)
            .IsRequired(false)
            .HasMaxLength(150);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
