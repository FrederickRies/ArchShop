using ArchShop.Models;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public class AddAddressToAccount : IRequest<AddressModel>
    {
    }
}
