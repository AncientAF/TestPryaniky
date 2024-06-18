namespace TestPryaniky.Application.Orders.Commands;

public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusCommandValidator()
    {
        RuleFor(c => c.Status)
            .IsInEnum()
            .WithMessage("Must be in OrderStatus enum");
    }
}