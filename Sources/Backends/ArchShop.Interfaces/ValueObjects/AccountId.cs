using System;

namespace ArchShop.ValueObjects
{
    public record AccountId(Guid Value)
    {
        public static AccountId New() => new AccountId(Guid.NewGuid());
    }
}
