using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class RemoveAddressFromAccountHandler : IRequestHandler<RemoveAddressFromAccount, Unit>
    {
        private readonly AccountLogic _accountLogic;

        public RemoveAddressFromAccountHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<Unit> Handle(RemoveAddressFromAccount request, CancellationToken cancellationToken)
        {
            await _accountLogic.RemoveAddressAsync(request.AccountId, request.AddressId, cancellationToken);
            return Unit.Value;
        }
    }
}
