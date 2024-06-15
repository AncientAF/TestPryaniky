using TestPryaniky.Core.Abstractions;

namespace TestPryaniky.Core.Models;

public class Product : Entity<Guid>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}