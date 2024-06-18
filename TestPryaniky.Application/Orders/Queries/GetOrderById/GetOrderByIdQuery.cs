namespace TestPryaniky.Application.Orders.Queries;

public record GetOrderByIdQuery(Guid Id) : IQuery<GetOrderByIdResult>;
public record GetOrderByIdResult(OrderDto Order);