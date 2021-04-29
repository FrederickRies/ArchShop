using System;

namespace ArchShop.Backend.Data
{
    public enum OrderStatus
    {
        Basket,
        Payed,
        Delivered
    }

    public record Order(
        Guid Id, 
        OrderStatus Status, 
        Guid CustomerId,
        DateTimeOffset CreationDate);
}
