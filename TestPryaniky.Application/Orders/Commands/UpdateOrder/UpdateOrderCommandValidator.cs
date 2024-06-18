namespace TestPryaniky.Application.Orders.Commands;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Status)
            .IsInEnum()
            .WithMessage("Must be in OrderStatus enum");

        RuleFor(c => c.Phone)
            .MinimumLength(11)
            .WithMessage("Length must be greater than 11");

        RuleForEach(c => c.Items)
            .Must(i => i.Quantity > 0)
            .WithMessage("Quantity must be greater than 0");
        
        RuleFor(c => c.Status)
            .IsInEnum()
            .WithMessage("Must be in OrderStatus enum");
    }
}