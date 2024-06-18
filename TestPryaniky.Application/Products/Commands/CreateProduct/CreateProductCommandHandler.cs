namespace TestPryaniky.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await productRepository.Create(request.Adapt<Product>(), cancellationToken);

        return new CreateProductResult(result);
    }
}