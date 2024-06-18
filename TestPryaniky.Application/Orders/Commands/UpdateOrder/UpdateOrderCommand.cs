namespace TestPryaniky.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(
    Guid Id,
    string Phone,
    AddressDto Address,
    List<(Guid productId, int quantity)> Items,
    OrderStatus Status) : ICommand<UpdateOrderResult>;
public record UpdateOrderResult(bool IsSuccess);