using System;

namespace ArchShop.Data
{
    public record Delivery(
        Guid Id, 
        DateTimeOffset DeliveryDate, 
        Guid AddressId, 
        Guid CommandId);
}
