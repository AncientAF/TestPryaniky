namespace TestPryaniky.Application.Dtos;

public class OrderItemDto
{
    public Guid Id { get; set; }
    public required ProductDto Product { get; set; }
    public required int Quantity { get; set; }
    public decimal TotalPrice => Product.Price * Quantity;
}