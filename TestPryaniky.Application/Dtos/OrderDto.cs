namespace TestPryaniky.Application.Dtos;

public class OrderDto
{
    public Guid Id { get; set; }
    public required string Phone { get; set; }
    public required AddressDto Address { get; set; }
    public required IEnumerable<OrderItemDto> OrderItems { get; set; }
    public OrderStatus Status { get; set; }
    public decimal? TotalPrice => OrderItems.Sum(i => i.Quantity * i.Product.Price);
}