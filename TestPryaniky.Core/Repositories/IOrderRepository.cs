using TestPryaniky.Core.Enums;

namespace TestPryaniky.Core.Repositories;

public interface IOrderRepository
{
    Task<Guid> Create();
    Task<Order> GetByStatus(OrderStatus status);
    Task<Product> GetByName(string name);
    Task<(IEnumerable<Order> products, long count)> GetPaginated(int pageIndex, int pageSize);
    Task Delete(Guid id);
    Task Update(Order updatedOrder);
    Task AddOrderItems(Guid id, IEnumerable<OrderItem> items);
    Task DeleteOrderItems(Guid id, IEnumerable<Guid> items);
    Task UpdateStatus(Guid Id, OrderStatus status);
}