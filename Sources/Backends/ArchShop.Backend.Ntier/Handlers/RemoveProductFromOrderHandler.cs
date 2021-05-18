using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class RemoveProductFromOrderHandler : IRequestHandler<RemoveProductFromOrder, Unit>
    {
        private readonly OrderLogic _orderLogic;

        public RemoveProductFromOrderHandler(OrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public async Task<Unit> Handle(RemoveProductFromOrder request, CancellationToken cancellationToken)
        {
            await _orderLogic.RemoveProductAsync(request.OrderId, request.ProductId, cancellationToken);
            return Unit.Value;
        }
    }
}
