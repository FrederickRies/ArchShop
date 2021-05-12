using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class PayOrderHandler : IRequestHandler<PayOrder, Unit>
    {
        private readonly AccountLogic _accountLogic;

        public PayOrderHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<Unit> Handle(PayOrder request, CancellationToken cancellationToken)
        {
        }
    }
}
