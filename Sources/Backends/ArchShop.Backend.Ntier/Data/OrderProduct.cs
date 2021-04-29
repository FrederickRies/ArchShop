using System;

namespace ArchShop.Backend.Data
{
    public record CommandProduct(
        Guid CommandId,
        Guid ProductId);
}
