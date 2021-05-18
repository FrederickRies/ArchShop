using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record RemoveProductFromOrder(OrderId OrderId, ProductId ProductId)
        : IRequest<Unit>;
}
