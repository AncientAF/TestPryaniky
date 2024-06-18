namespace TestPryaniky.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetById(request.Id, cancellationToken);

        return new GetOrderByIdResult(order.Adapt<OrderDto>());
    }
}