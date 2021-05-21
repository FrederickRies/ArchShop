using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record RemoveAddressFromAccount(AddressId AddressId)
        : IRequest<Unit>;
}
