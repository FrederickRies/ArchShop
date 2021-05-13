using System;

namespace ArchShop.ValueObjects
{
    public record OrderId(Guid Value)
    {
        public static OrderId New => new OrderId(Guid.NewGuid());
    }
}
