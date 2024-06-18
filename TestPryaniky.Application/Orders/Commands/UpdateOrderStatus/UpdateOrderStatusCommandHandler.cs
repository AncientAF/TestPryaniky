namespace TestPryaniky.Application.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<UpdateOrderStatusCommand, UpdateOrderStatusResult>
{
    public async Task<UpdateOrderStatusResult> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        await orderRepository.UpdateStatus(request.Id, request.Status, cancellationToken);

        return new UpdateOrderStatusResult(true);
    }
}