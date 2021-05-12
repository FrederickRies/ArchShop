using ArchShop.Business;
using ArchShop.Interfaces.Queries;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetails, OrderDetailsModel>
    {
        private readonly AccountLogic _accountLogic;

        public GetOrderDetailsHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<OrderDetailsModel> Handle(GetOrderDetails request, CancellationToken cancellationToken)
        {
        }
    }
}
