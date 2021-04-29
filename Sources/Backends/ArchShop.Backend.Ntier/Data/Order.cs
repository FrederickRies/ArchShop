using System;

namespace ArchShop.Data
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
        Guid AccountId,
        DateTimeOffset CreationDate);
}
