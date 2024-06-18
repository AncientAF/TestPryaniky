namespace TestPryaniky.Application.Orders.Commands;

public record DeleteItemsFromOrderCommand(Guid OrderId, List<Guid> Items) : ICommand<DeleteItemsFromOrderResult>;
public record DeleteItemsFromOrderResult(bool IsSuccess);