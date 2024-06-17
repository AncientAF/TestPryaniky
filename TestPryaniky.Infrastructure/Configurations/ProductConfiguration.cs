using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestPryaniky.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired();

        builder.Property(p => p.Description).IsRequired();

        builder.Property(p => p.Price).IsRequired();
    }
}