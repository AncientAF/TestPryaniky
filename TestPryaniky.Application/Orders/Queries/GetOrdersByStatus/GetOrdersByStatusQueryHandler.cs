namespace TestPryaniky.Application.Orders.Queries.GetOrdersByStatus;

public class GetOrdersByStatusQueryHandler(IOrderRepository orderRepository)
    : IQueryHandler<GetOrdersByStatusQuery, GetOrdersByStatusResult>
{
    public async Task<GetOrdersByStatusResult> Handle(GetOrdersByStatusQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetByStatus(request.Status, cancellationToken);

        return new GetOrdersByStatusResult(orders.Adapt<IEnumerable<OrderDto>>());
    }
}