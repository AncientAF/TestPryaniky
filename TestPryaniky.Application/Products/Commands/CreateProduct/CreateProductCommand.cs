namespace TestPryaniky.Application.Products.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);