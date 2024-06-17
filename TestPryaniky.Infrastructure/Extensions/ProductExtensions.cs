namespace TestPryaniky.Infrastructure.Extensions;

public static class ProductExtensions
{
    public static void Update(this Product product, Product updatedProduct)
    {
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;
    }
}