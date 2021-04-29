using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Interfaces.Queries;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class GetAccountHandler : IRequestHandler<GetAccount, AccountDetailsModel>
    {
        private readonly AccountLogic _accountLogic;

        public GetAccountHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<AccountDetailsModel> Handle(GetAccount request, CancellationToken cancellationToken)
        {
            var account = await _accountLogic.GetAccountAsync(request.AccountId);
            return new AccountDetailsModel(
                account.Id,
                account.FirstName,
                account.LastName);
        }
    }
}
