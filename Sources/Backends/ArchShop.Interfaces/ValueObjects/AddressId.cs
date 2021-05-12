using System;

namespace ArchShop.ValueObjects
{
    public record AddressId(Guid Value)
    {
        public static AddressId New => new AddressId(Guid.NewGuid());
    }
}
