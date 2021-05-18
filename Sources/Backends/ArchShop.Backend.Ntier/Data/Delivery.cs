using ArchShop.ValueObjects;
using System;

namespace ArchShop.Data
{
    public record Delivery(
        DeliveryId Id,
        OrderId OrderId,
        AddressId AddressId,
        DateTimeOffset DeliveryDate);
}
