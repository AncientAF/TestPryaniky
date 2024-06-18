namespace TestPryaniky.Application.Products.Queries.GetProductByName;

public record GetProductByNameQuery(string Name) : IQuery<GetProductByNameResult>;
public record GetProductByNameResult(ProductDto Product);