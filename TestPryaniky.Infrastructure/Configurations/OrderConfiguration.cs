using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestPryaniky.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Phone).IsRequired();

        builder.Property(o => o.Status).IsRequired();

        builder
            .HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .IsRequired();

        builder.OwnsOne(o => o.Address);
    }
}