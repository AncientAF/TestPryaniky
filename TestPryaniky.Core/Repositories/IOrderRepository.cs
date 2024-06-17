using TestPryaniky.Core.Enums;

namespace TestPryaniky.Core.Repositories;

public interface IOrderRepository
{
    Task<Guid> Create(Order order, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetByStatus(OrderStatus status, CancellationToken cancellationToken);
    Task<(IEnumerable<Order> orders, long count)> GetPaginated(int pageIndex, int pageSize,
        CancellationToken cancellationToken);

    Task<Order> GetById(Guid id, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Update(Order updatedOrder, CancellationToken cancellationToken);
    Task AddOrderItems(Guid id, IEnumerable<OrderItem> items, CancellationToken cancellationToken);
    Task DeleteOrderItems(Guid id, IEnumerable<Guid> items, CancellationToken cancellationToken);
    Task UpdateStatus(Guid id, OrderStatus status, CancellationToken cancellationToken);
}