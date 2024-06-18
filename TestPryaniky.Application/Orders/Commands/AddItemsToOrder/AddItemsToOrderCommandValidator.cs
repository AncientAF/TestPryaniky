namespace TestPryaniky.Application.Orders.Commands;

public class AddItemsToOrderCommandValidator : AbstractValidator<AddItemsToOrderCommand>
{
    public AddItemsToOrderCommandValidator()
    {
        RuleForEach(c => c.Items)
            .Must(i => i.Quantity > 0)
            .WithMessage("Quantity must be greater than 0");
    }
}