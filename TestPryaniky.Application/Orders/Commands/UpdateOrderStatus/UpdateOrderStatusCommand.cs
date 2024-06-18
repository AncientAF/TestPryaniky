namespace TestPryaniky.Application.Orders.Commands.UpdateOrderStatus;

public record UpdateOrderStatusCommand(Guid Id, OrderStatus Status) : ICommand<UpdateOrderStatusResult>;
public record UpdateOrderStatusResult(bool IsSuccess);