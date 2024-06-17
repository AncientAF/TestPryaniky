namespace TestPryaniky.Core.Repositories;

public interface IProductRepository
{
    Task<Guid> Create(Product product, CancellationToken cancellationToken);
    Task<Product> GetById(Guid id, CancellationToken cancellationToken);
    Task<Product> GetByName(string name, CancellationToken cancellationToken);
    Task<(IEnumerable<Product> products, long count)> GetPaginated(int pageIndex, int pageSize, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Update(Product updatedProduct, CancellationToken cancellationToken);
}