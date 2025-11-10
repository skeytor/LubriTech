using LubriTech.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TableNames.Products);
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(150);

        builder.Property(x => x.Stock)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasIndex(x => x.Sku)
            .IsUnique();

        builder.Property(x => x.Sku)
            .HasConversion(
                sku => sku.Value,
                value => Sku.Create(value)!)
            .IsRequired()
            .HasMaxLength(15);

        builder.ComplexProperty(x => x.SellingPrice, builder =>
        {
            builder.Property(p => p.Amount)
                 .HasColumnName("Price")
                 .IsRequired();

            builder.Property(p => p.Currency)
                .HasColumnName("Currency")
                .IsRequired()
                .HasMaxLength(3);
        });

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedAt)
            .HasDefaultValueSql("now()")
            .ValueGeneratedOnUpdateSometimes();

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.BrandId);
    }
}
