namespace TestPryaniky.Core.Repositories;

public interface IProductRepository
{
    Task<Guid> Create();
    Task<Product> GetById(Guid id);
    Task<Product> GetByName(string name);
    Task<(IEnumerable<Product> products, long count)> GetPaginated(int pageIndex, int pageSize);
    Task Delete(Guid id);
    Task Update(Product updatedProduct);
}