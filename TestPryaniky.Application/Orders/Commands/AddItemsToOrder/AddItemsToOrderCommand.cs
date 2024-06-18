namespace TestPryaniky.Application.Orders.Commands;

public record AddItemsToOrderCommand(Guid Id, List<ProductIdWithQuantity> Items) : ICommand<AddItemsToOrderResult>;
public record AddItemsToOrderResult(bool IsSuccess);