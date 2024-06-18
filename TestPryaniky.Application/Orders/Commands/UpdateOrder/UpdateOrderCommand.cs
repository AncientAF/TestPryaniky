namespace TestPryaniky.Application.Orders.Commands;

public record UpdateOrderCommand(
    Guid Id,
    string Phone,
    AddressDto Address,
    List<ProductIdWithQuantity> Items,
    OrderStatus Status) : ICommand<UpdateOrderResult>;
public record UpdateOrderResult(bool IsSuccess);