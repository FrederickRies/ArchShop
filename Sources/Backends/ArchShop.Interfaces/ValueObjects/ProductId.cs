using System;

namespace ArchShop.ValueObjects
{
    public record ProductId(Guid Value)
    {
        public static ProductId New => new ProductId(Guid.NewGuid());
    }
}
