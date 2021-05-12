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
        private readonly AccountLogic _accountLogic;

        public DeleteOrderHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<Unit> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
        }
    }
}
