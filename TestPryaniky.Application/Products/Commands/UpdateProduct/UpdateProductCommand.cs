namespace TestPryaniky.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(ProductDto Product) : ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);