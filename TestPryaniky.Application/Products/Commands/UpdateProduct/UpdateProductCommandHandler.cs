namespace TestPryaniky.Application.Products.Commands;

public class UpdateProductCommandHandler(IProductRepository productRepository)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await productRepository.Update(request.Product.Adapt<Product>(), cancellationToken);

        return new UpdateProductResult(true);
    }
}