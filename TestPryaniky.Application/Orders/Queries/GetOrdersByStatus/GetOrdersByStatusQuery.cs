namespace TestPryaniky.Application.Orders.Queries.GetOrdersByStatus;

public record GetOrdersByStatusQuery(OrderStatus Status) : IQuery<GetOrdersByStatusResult>;
public record GetOrdersByStatusResult(IEnumerable<OrderDto> Orders);