namespace TestPryaniky.Application.Orders.Commands;

public record UpdateOrderStatusCommand(Guid Id, OrderStatus Status) : ICommand<UpdateOrderStatusResult>;
public record UpdateOrderStatusResult(bool IsSuccess);