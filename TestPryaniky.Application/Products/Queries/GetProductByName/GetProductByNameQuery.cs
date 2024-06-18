namespace TestPryaniky.Application.Products.Queries;

public record GetProductByNameQuery(string Name) : IQuery<GetProductByNameResult>;
public record GetProductByNameResult(ProductDto Product);