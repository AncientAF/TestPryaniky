namespace TestPryaniky.Core.Exceptions;

public class OrderNotFoundException(object key) : NotFoundException("Order", key);