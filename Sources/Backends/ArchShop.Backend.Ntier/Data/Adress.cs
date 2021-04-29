using System;

namespace ArchShop.Data
{
    public record Adress(
        Guid Id, 
        Guid AccountId, 
        string Street, 
        string City);
}
