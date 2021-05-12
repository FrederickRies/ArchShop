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
        private readonly AccountLogic _accountLogic;

        public GetOrdersHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<IEnumerable<OrderListModel>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
        }
    }
}
