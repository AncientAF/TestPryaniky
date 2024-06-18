namespace TestPryaniky.Application.Orders.Commands.DeleteItemsFromOrder;

public record DeleteItemsFromOrderCommand(Guid OrderId, List<Guid> Items) : ICommand<DeleteItemsFromOrderResult>;
public record DeleteItemsFromOrderResult(bool IsSuccess);