using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record PayOrder(OrderId OrderId) : IRequest<Unit>;
}
