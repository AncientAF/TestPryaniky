namespace TestPryaniky.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(string Phone, AddressDto Address, List<(Guid productId, int quantity)> Items, OrderStatus Status) : ICommand<CreateOrderResult>;
public record CreateOrderResult(Guid Id);