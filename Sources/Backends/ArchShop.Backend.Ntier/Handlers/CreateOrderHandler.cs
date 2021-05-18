using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrder, OrderDetailsModel>
    {
        private readonly OrderLogic _orderLogic;

        public CreateOrderHandler(OrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public async Task<OrderDetailsModel> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
        }
    }
}
