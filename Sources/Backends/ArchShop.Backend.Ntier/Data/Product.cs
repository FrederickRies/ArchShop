using System;

namespace ArchShop.Backend.Data
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Libelle { get; set; }
        public int RemainingStock { get; set; }
    }
}
