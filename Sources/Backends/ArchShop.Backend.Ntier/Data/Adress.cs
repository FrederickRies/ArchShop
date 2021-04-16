using System;

namespace ArchShop.Backend.Ntier.Data
{
    public class Adress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
