using System;

namespace ArchShop.Backend.Data
{
    public enum CommandStatus
    {
        Basket,
        Payed,
        Delivered
    }

    public class Command
    {
        public Guid Id { get; set; }
        public CommandStatus Status { get; set; }
        public Guid CustomerId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
