using System;

namespace ArchShop.Backend.Data
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public Guid AddressId { get; set; }
        public Guid CommandId { get; set; }
    }
}
