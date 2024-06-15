namespace TestPryaniky.Core.Exceptions;

public class ProductNotFoundException(object key) : NotFoundException("Product", key);