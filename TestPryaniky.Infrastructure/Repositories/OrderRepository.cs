using TestPryaniky.Core.Enums;
using TestPryaniky.Core.Repositories;
using TestPryaniky.Infrastructure.Extensions;

namespace TestPryaniky.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext dbContext)
    : IOrderRepository
{
    public async Task<Guid> Create(Order order, CancellationToken cancellationToken)
    {
        var result = await dbContext.Orders.AddAsync(order, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
        
        return result.Entity.Id;
    }

    public async Task<IEnumerable<Order>> GetByStatus(OrderStatus status, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders.AsNoTracking().Include(o => o.OrderItems).ThenInclude(oi => oi.Product).Where(o => o.Status == status).ToListAsync(cancellationToken);

        return orders;
    }
    
    public async Task<(IEnumerable<Order> orders, long count)> GetPaginated(int pageIndex, int pageSize,
        CancellationToken cancellationToken)
    {
        var orders = (await dbContext.Orders.AsNoTracking()
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Skip(pageIndex * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken)
                ).OrderBy(o => o.TotalPrice);

        var count = await dbContext.Orders.LongCountAsync(cancellationToken);

        return (orders, count);
    }

    public async Task<Order> GetById(Guid id, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.AsNoTracking().Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (order == null) throw new OrderNotFoundException(id);

        return order;
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (order == null) throw new OrderNotFoundException(id);
        
        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(Order updatedOrder, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == updatedOrder.Id, cancellationToken);

        if (order == null) throw new OrderNotFoundException(updatedOrder.Id);

        order.Update(updatedOrder);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddOrderItems(Guid id, IEnumerable<OrderItem> items, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (order == null) throw new OrderNotFoundException(id);
        
        order.OrderItems = order.OrderItems.Concat(items).ToList();

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteOrderItems(Guid id, IEnumerable<Guid> items, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (order == null) throw new OrderNotFoundException(id);
        
        var toDelete = order.OrderItems.Where(oi => items.Contains(oi.Id));

        order.OrderItems = order.OrderItems.Except(toDelete);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateStatus(Guid id, OrderStatus status, CancellationToken cancellationToken)
    {
        var order = await dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (order == null) throw new OrderNotFoundException(id);

        order.Status = status;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}