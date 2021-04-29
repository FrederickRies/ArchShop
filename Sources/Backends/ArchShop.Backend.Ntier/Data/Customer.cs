using System;

namespace ArchShop.Backend.Data
{
    public record Customer(
        Guid Id, 
        string FirstName, 
        string LastName);
}
