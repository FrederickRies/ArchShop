using System;

namespace ArchShop.Backend.Data
{
    public record Delivery(
        Guid Id, 
        DateTimeOffset DeliveryDate, 
        Guid AddressId, 
        Guid CommandId);
}
