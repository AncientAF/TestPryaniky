using TestPryaniky.Application.Pagination;

namespace TestPryaniky.Application.Orders.Queries;

public class GetOrdersPaginatedQueryHandler(IOrderRepository orderRepository)
    : IQueryHandler<GetOrdersPaginatedQuery, GetOrdersPaginatedResult>
{
    public async Task<GetOrdersPaginatedResult> Handle(GetOrdersPaginatedQuery request, CancellationToken cancellationToken)
    {
        var (pageIndex, pageSize) = request.PaginationRequest;
        
        var (orders, count) = await orderRepository.GetPaginated(pageIndex, pageSize, cancellationToken);

        var result = new PaginatedResult<OrderDto>(pageIndex, pageSize, count, orders.Adapt<IEnumerable<OrderDto>>());

        return new GetOrdersPaginatedResult(result);
    }
}