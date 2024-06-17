using TestPryaniky.Core.Repositories;
using TestPryaniky.Infrastructure.Extensions;

namespace TestPryaniky.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext dbContext)
    : IProductRepository
{
    public async Task<Guid> Create(Product product, CancellationToken cancellationToken)
    {
        var result = await dbContext.Products.AddAsync(product, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }

    public async Task<Product> GetById(Guid id, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product == null) throw new ProductNotFoundException(id);

        return product;
    }

    public async Task<Product> GetByName(string name, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name, cancellationToken);

        if (product == null) throw new ProductNotFoundException("Name", name);

        return product;
    }

    public async Task<(IEnumerable<Product> products, long count)> GetPaginated(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        var products = await dbContext.Products.AsNoTracking()
            .Skip(pageIndex * pageSize).Take(pageSize)
            .OrderBy(o => o.Name)
            .ToListAsync(cancellationToken);

        var count = await dbContext.Products.LongCountAsync(cancellationToken);

        return (products, count);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product == null) throw new ProductNotFoundException(id);
        
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Product updatedProduct, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(o => o.Id == updatedProduct.Id, cancellationToken);

        if (product == null) throw new ProductNotFoundException(updatedProduct.Id);

        product.Update(updatedProduct);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}