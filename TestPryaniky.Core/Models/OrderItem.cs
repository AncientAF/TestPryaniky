using TestPryaniky.Core.Abstractions;

namespace TestPryaniky.Core.Models;

public class OrderItem : Entity<Guid>
{
    public required Guid OrderId { get; set; }
    public required Guid ProductId { get; set; }
    public  Product Product { get; set; }
    public required int Quantity { get; set; }
    public decimal TotalPrice => Product.Price * Quantity;
}