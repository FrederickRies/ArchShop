using System;

namespace ArchShop.Backend.Data
{
    public record Product(
        Guid Id,
        string Libelle,
        int RemainingStock);
}
