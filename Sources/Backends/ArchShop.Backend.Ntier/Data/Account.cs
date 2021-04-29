using System;

namespace ArchShop.Data
{
    public record Customer(
        Guid Id, 
        string FirstName, 
        string LastName);
}
