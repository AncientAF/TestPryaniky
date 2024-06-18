namespace TestPryaniky.Application.Products.Queries.GetProductByName;

public class GetProductByNameQueryHandler(IProductRepository productRepository)
    : IQueryHandler<GetProductByNameQuery, GetProductByNameResult>
{
    public async Task<GetProductByNameResult> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByName(request.Name, cancellationToken);

        return new GetProductByNameResult(product.Adapt<ProductDto>());
    }
}