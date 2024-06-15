namespace TestPryaniky.Core.Enums;

public enum OrderStatus
{
    Pending,      // Ожидает обработки
    Processing,   // В обработке
    Shipped,      // Отправлен
    Delivered,    // Доставлен
    Cancelled     // Отменен
}