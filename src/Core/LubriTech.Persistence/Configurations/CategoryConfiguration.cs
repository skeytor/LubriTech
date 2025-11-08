using LubriNet.Persistence.Configurations;
using LubriTech.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubriTech.Persistence.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(TableNames.Categories);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(150);
    }
}
