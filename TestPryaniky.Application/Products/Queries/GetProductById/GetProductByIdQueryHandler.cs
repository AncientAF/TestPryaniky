namespace TestPryaniky.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.Id, cancellationToken);

        return new GetProductByIdResult(product.Adapt<ProductDto>());
    }
}