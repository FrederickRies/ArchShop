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
        private readonly AccountLogic _accountLogic;

        public AddProductToOrderHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<Unit> Handle(AddProductToOrder request, CancellationToken cancellationToken)
        {
        }
    }
}
