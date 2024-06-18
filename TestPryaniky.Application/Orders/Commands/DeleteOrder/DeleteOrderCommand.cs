namespace TestPryaniky.Application.Orders.Commands;

public record DeleteOrderCommand(Guid Id) : ICommand<DeleteOrderResult>;
public record DeleteOrderResult(bool IsSuccess);