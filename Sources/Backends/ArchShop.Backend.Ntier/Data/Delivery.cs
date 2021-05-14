using ArchShop.ValueObjects;
using System;

namespace ArchShop.Data
{
    public record Delivery(
        DeliveryId Id,
        OrderId OrderId,
        DateTimeOffset DeliveryDate, 
        AddressId AddressId);
}
