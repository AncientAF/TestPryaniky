using TestPryaniky.Core.Abstractions;

namespace TestPryaniky.Core.Models;

public class OrderItem : Entity<Guid>
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public required Product Product { get; set; }
    public int Quantity { get; set; }
}