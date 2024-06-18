namespace TestPryaniky.Application.Orders.Commands.AddItemsToOrder;

public record AddItemsToOrderCommand(Guid Id, List<(Guid productId, int quantity)> Items) : ICommand<AddItemsToOrderResult>;
public record AddItemsToOrderResult(bool IsSuccess);