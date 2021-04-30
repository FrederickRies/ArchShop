using ArchShop.ValueObjects;

namespace ArchShop.Data
{
    public record Address(
        AddressId Id, 
        AccountId AccountId, 
        string Street, 
        string City);
}
