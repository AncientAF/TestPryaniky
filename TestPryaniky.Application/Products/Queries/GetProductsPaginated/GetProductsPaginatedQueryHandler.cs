using TestPryaniky.Application.Orders.Queries.GetOrdersPaginated;
using TestPryaniky.Application.Pagination;

namespace TestPryaniky.Application.Products.Queries.GetProductsPaginated;

public class GetProductsPaginatedQueryHandler(IProductRepository productRepository)
    : IQueryHandler<GetProductsPaginatedQuery, GetProductsPaginatedResult>
{
    public async Task<GetProductsPaginatedResult> Handle(GetProductsPaginatedQuery request, CancellationToken cancellationToken)
    {
        var (pageIndex, pageSize) = request.PaginationRequest;

        var (products, count) = await productRepository.GetPaginated(pageIndex, pageSize, cancellationToken);

        var result = new PaginatedResult<ProductDto>(pageIndex, pageSize, count, products.Adapt<IEnumerable<ProductDto>>());

        return new GetProductsPaginatedResult(result);
    }
}