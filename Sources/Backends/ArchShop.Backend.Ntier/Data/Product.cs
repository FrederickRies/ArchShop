using ArchShop.ValueObjects;

namespace ArchShop.Data
{
    public record Product(
        ProductId Id,
        string Label,
        string Description,
        int RemainingStock);
}
