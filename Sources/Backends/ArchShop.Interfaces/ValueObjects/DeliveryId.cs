using System;

namespace ArchShop.ValueObjects
{
    public record DeliveryId(Guid Value)
    {
        public static DeliveryId New => new DeliveryId(Guid.NewGuid());
    }
}
