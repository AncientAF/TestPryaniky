using TestPryaniky.Application.Pagination;

namespace TestPryaniky.Application.Products.Queries;

public record GetProductsPaginatedQuery(PaginationRequest PaginationRequest) : IQuery<GetProductsPaginatedResult>;
public record GetProductsPaginatedResult(PaginatedResult<ProductDto> Products);