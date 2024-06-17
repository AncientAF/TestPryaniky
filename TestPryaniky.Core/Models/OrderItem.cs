using TestPryaniky.Core.Abstractions;

namespace TestPryaniky.Core.Models;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public required Product Product { get; set; }
    public required int Quantity { get; set; }
    public decimal TotalPrice => Product.Price * Quantity;
}