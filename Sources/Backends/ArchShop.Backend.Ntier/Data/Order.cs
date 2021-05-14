using ArchShop.ValueObjects;
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
        OrderId Id, 
        OrderStatus Status, 
        AccountId AccountId,
        DateTimeOffset CreationDate);
}
