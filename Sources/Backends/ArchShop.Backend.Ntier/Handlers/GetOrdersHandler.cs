using ArchShop.Business;
using ArchShop.Interfaces.Queries;
using ArchShop.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrders, IEnumerable<OrderListModel>>
    {
        private readonly OrderLogic _orderLogic;

        public GetOrdersHandler(OrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public async Task<IEnumerable<OrderListModel>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
        }
    }
}
