using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class AddAddressToAccountHandler : IRequestHandler<AddAddressToAccount, AddressModel>
    {
        private readonly AccountLogic _accountLogic;

        public AddAddressToAccountHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<AddressModel> Handle(AddAddressToAccount request, CancellationToken cancellationToken)
        {
            var address = await _accountLogic.CreateAddressAsync(
                request.AccountId,
                request.Street,
                request.City,
                cancellationToken);
            return new AddressModel(
                address.Id.Value,
                address.Street,
                address.City);
        }
    }
}
