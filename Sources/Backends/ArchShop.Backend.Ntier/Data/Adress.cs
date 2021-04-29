using System;

namespace ArchShop.Backend.Data
{
    public record Adress(
        Guid Id, 
        Guid CustomerId, 
        string Street, 
        string City);
}
