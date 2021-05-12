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
        private readonly AccountLogic _accountLogic;

        public CreateOrderHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<OrderDetailsModel> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
        }
    }
}
