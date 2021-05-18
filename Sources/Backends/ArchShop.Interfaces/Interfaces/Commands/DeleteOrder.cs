using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record DeleteOrder(OrderId OrderId)
        : IRequest<Unit>;
}
