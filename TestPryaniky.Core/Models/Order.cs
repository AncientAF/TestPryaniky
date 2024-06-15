using TestPryaniky.Core.Abstractions;
using TestPryaniky.Core.Enums;

namespace TestPryaniky.Core.Models;

public class Order : Entity<Guid>
{
    public required string Phone { get; set; }
    public required Address Address { get; set; }
    public required IEnumerable<OrderItem> OrderItems { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalPrice => OrderItems.Sum(i => i.Quantity * i.Product.Price);
}