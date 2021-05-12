using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record RemoveAddressFromAccount(AccountId AccountId, AddressId AddressId)
        : IRequest<Unit>;
}
