namespace TestPryaniky.Application.Products.Commands;

public record UpdateProductCommand(ProductDto Product) : ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);