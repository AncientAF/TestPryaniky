namespace TestPryaniky.Core.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(string keyName, object key) : base("Product", keyName, key)
    {
        
    }

    public ProductNotFoundException(object key) : base("Product", key)
    {
    }
}