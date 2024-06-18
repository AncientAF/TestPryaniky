namespace TestPryaniky.Application.Products.Commands;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Product.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }   
}