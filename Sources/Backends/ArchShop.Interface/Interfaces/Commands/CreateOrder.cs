using ArchShop.Models;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public class CreateOrder : IRequest<OrderDetailsModel>
    {
    }
}
