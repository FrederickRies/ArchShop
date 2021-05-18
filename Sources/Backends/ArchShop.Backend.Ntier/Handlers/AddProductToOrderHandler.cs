using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class AddProductToOrderHandler : IRequestHandler<AddProductToOrder, Unit>
    {
        private readonly OrderLogic _orderLogic;

        public AddProductToOrderHandler(OrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public async Task<Unit> Handle(AddProductToOrder request, CancellationToken cancellationToken)
        {
            await _orderLogic.AddProductAsync(
                request.OrderId,
                request.ProductId,
                request.Count,
                cancellationToken);
            return Unit.Value;
        }
    }
}
