namespace TestPryaniky.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await productRepository.Delete(request.Id, cancellationToken);

        return new DeleteProductResult(true);
    }
}