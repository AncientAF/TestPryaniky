namespace TestPryaniky.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(ProductDto Product);