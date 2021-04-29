using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class RegisterAccountHandler : IRequestHandler<RegisterAccount, AccountDetailsModel>
    {
        private readonly AccountLogic _accountLogic;

        public RegisterAccountHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<AccountDetailsModel> Handle(RegisterAccount request, CancellationToken cancellationToken)
        {
            var account = await _accountLogic.CreateAccountAsync(
                request.FirstName, 
                request.LastName);
            return new AccountDetailsModel(
                account.Id,
                account.FirstName,
                account.LastName);
        }
    }
}
