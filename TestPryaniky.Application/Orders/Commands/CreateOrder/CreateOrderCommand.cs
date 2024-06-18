namespace TestPryaniky.Application.Orders.Commands;

public record CreateOrderCommand(string Phone, AddressDto Address, List<ProductIdWithQuantity> Items, OrderStatus Status) : ICommand<CreateOrderResult>;
public record CreateOrderResult(Guid Id);