using TestPryaniky.Core.Enums;

namespace TestPryaniky.Infrastructure.Extensions;

public class InitialData
{
    public static List<Product> Products => new List<Product>()
    {
        new Product
        {
            Id = new Guid("F7BC974D-D757-44A2-BA43-3F1D38F839AE"),
            Name = "Product 1",
            Description = "Product 1",
            Price = 100
        },
        new Product
        {
            Id = new Guid("03DFE346-1473-4F07-862B-879E7FA47414"),
            Name = "Product 2",
            Description = "Product 2",
            Price = 200
        },
        new Product
        {
            Id = new Guid("2A124192-1DDE-4331-864F-58181A0A9FDB"),
            Name = "Product 3",
            Description = "Product 3",
            Price = 150
        },
        new Product
        {
            Id = new Guid("F1FD615D-3DCD-4B81-B5CD-51FDC198E988"),
            Name = "Product 4",
            Description = "Product 4",
            Price = 50
        },
        new Product
        {
            Id = new Guid("A969AF57-47DD-47E1-8942-D9556C393FA9"),
            Name = "Product 5",
            Description = "Product 5",
            Price = 500
        }
    };

    public static List<Order> Orders
    {
        get
        {
            var orderId1 = new Guid("1304ACE2-D7F9-499B-80AD-7709D0D18BDD");
            var orderId2 = new Guid("56CC7001-60B5-438E-9D22-0D48F227E122");
            
            var address1 = new Address
            {
                City = "City 1",
                Country = "Country 1",
                PostalCode = "111111",
                State = "State 1",
                Street = "Street 1"
            };
            
            var address2 = new Address
            {
                City = "City 2",
                Country = "Country 2",
                PostalCode = "222222",
                State = "State 2",
                Street = "Street 2"
            };
            
            var orderItems1 = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = new Guid("91D1CE77-A56A-4F29-92C7-5BA7370BE95C"),
                    OrderId = orderId1,
                    ProductId = Products[0].Id,
                    Product = Products[0],
                    Quantity = 2
                },
                new OrderItem
                {
                    Id = new Guid("6D3D4170-3356-48F8-990A-0151F4530D29"),
                    OrderId = orderId1,
                    ProductId = Products[1].Id,
                    Product = Products[1],
                    Quantity = 3
                }
            };
            
            var orderItems2 = new List<OrderItem>
            {
                new OrderItem
                {
                    Id = new Guid("72B23FCB-F9E2-45B9-A886-2D8ABFBA21A8"),
                    OrderId = orderId2,
                    ProductId = Products[2].Id,
                    Product = Products[2],
                    Quantity = 4
                },
                new OrderItem
                {
                    Id = new Guid("C05EB255-3CB8-490A-854F-3C1B13B1EF05"),
                    OrderId = orderId2,
                    ProductId = Products[3].Id,
                    Product = Products[3],
                    Quantity = 1
                },
                new OrderItem
                {
                    Id = new Guid("74B4FB3B-3B32-4399-8DF5-1016B7DC4CE1"),
                    OrderId = orderId2,
                    ProductId = Products[4].Id,
                    Product = Products[4],
                    Quantity = 5
                }
            };
            
            var order1 = new Order
            {
                Id = new Guid("D460641B-25C9-4BA9-95F3-F3A2D9869E66"),
                Address = address1,
                Status = OrderStatus.Pending,
                Phone = "79998887766",
                OrderItems = orderItems1
            };
            
            var order2 = new Order
            {
                Id = new Guid("8A4E38AC-78F8-4C05-9087-EE4C9666F237"),
                Address = address2,
                Status = OrderStatus.Pending,
                Phone = "79886663311",
                OrderItems = orderItems2
            };

            return new List<Order> {order1, order2};
        }
    }
}