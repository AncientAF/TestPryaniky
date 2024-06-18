using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestPryaniky.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        builder.HasOne<Order>().WithMany(o => o.OrderItems).HasForeignKey(oi => oi.OrderId).IsRequired();

        builder.HasOne(oi => oi.Product).WithMany().HasForeignKey(oi => oi.ProductId);

        builder.Property(oi => oi.Quantity).IsRequired();
    }
}