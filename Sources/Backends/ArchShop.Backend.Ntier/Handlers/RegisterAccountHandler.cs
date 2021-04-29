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

        public Task<AccountDetailsModel> Handle(RegisterAccount request, CancellationToken cancellationToken)
        {
            var account = _accountLogic.CreateAccount(request.FirstName, request.LastName);
        }
    }
}
