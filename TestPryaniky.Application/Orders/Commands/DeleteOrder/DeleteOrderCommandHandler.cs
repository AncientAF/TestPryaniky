namespace TestPryaniky.Application.Orders.Commands;

public class DeleteOrderCommandHandler(IOrderRepository orderRepository)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await orderRepository.Delete(request.Id, cancellationToken);

        return new DeleteOrderResult(true);
    }
}