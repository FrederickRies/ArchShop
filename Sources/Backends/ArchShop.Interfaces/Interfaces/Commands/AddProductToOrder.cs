using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public record AddProductToOrder(OrderId OrderId, ProductId ProductId, int Count) 
        : IRequest<Unit>;
}
