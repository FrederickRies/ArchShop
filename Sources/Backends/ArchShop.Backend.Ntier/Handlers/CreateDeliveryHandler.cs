using ArchShop.Business;
using ArchShop.Interfaces.Commands;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDelivery, DeliveryDetailsModel>
    {
        private readonly AccountLogic _accountLogic;

        public CreateDeliveryHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<DeliveryDetailsModel> Handle(CreateDelivery request, CancellationToken cancellationToken)
        {
        }
    }
}
