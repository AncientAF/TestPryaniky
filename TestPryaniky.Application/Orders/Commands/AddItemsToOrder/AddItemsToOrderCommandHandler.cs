namespace TestPryaniky.Application.Orders.Commands;

public class AddItemsToOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<AddItemsToOrderCommand, AddItemsToOrderResult>
{
    public async Task<AddItemsToOrderResult> Handle(AddItemsToOrderCommand request, CancellationToken cancellationToken)
    {
        await orderRepository.AddOrderItems(request.Id, request.Items.ToOrderItemList(request.Id), cancellationToken);

        return new AddItemsToOrderResult(true);
    }
}