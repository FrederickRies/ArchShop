using ArchShop.Models;
using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record AddAddressToAccount(AccountId AccountId, string Street, string City) 
        : IRequest<AddressModel>;
}
