using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrder, Unit>
    {
        private readonly OrderLogic _orderLogic;

        public DeleteOrderHandler(OrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public async Task<Unit> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
            await _orderLogic.RemoveAsync(request.OrderId, cancellationToken);
            return Unit.Value;
        }
    }
}
