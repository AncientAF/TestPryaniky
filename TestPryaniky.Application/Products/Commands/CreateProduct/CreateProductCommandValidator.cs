namespace TestPryaniky.Application.Products.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }
}