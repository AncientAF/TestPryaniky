namespace TestPryaniky.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = request.Adapt<Order>();
        
        order.Id = new Guid();
        order.OrderItems = request.Items.ToOrderItemList(order.Id);
        
        var result = await orderRepository.Create(order, cancellationToken);

        return new CreateOrderResult(result);
    }
}