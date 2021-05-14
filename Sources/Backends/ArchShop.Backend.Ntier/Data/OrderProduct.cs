using ArchShop.ValueObjects;

namespace ArchShop.Data
{
    public record OrderProduct(
        OrderId OrderId,
        ProductId ProductId);
}
