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
        private readonly AccountLogic _accountLogic;

        public RemoveProductFromOrderHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<Unit> Handle(RemoveProductFromOrder request, CancellationToken cancellationToken)
        {
        }
    }
}
