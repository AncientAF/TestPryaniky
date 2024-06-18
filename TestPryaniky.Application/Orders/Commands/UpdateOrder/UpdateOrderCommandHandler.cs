namespace TestPryaniky.Application.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = request.Adapt<Order>();

        order.OrderItems = request.Items.ToOrderItemList(order.Id);
        await orderRepository.Update(order, cancellationToken);

        return new UpdateOrderResult(true);
    }
}