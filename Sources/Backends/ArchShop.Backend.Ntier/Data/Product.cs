using System;

namespace ArchShop.Data
{
    public record Product(
        Guid Id,
        string Libelle,
        int RemainingStock);
}
