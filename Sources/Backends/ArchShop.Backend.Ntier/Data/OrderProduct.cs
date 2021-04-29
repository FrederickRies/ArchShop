using System;

namespace ArchShop.Data
{
    public record CommandProduct(
        Guid OrderId,
        Guid ProductId);
}
