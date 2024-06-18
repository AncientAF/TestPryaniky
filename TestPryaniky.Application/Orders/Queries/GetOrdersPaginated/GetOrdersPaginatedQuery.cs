using TestPryaniky.Application.Pagination;

namespace TestPryaniky.Application.Orders.Queries.GetOrdersPaginated;

public record GetOrdersPaginatedQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersPaginatedResult>;
public record GetOrdersPaginatedResult(PaginatedResult<OrderDto> Orders);