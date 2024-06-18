namespace TestPryaniky.Application.Orders.Commands.DeleteItemsFromOrder;

public class DeleteItemsFromOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<DeleteItemsFromOrderCommand, DeleteItemsFromOrderResult>
{
    public async Task<DeleteItemsFromOrderResult> Handle(DeleteItemsFromOrderCommand request, CancellationToken cancellationToken)
    {
        await orderRepository.DeleteOrderItems(request.OrderId, request.Items, cancellationToken);

        return new DeleteItemsFromOrderResult(true);
    }
}