using System;

namespace ArchShop.Data
{
    public record Account(
        Guid Id, 
        string FirstName, 
        string LastName);
}
