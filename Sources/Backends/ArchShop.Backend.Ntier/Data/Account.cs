using ArchShop.ValueObjects;

namespace ArchShop.Data
{
    public record Account(
        AccountId Id, 
        string FirstName, 
        string LastName);
}
