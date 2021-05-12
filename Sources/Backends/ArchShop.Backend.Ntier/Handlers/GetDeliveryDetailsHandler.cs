using ArchShop.Business;
using ArchShop.Interfaces.Queries;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class GetDeliveryDetailsHandler : IRequestHandler<GetDeliveryDetails, DeliveryDetailsModel>
    {
        private readonly AccountLogic _accountLogic;

        public GetDeliveryDetailsHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<DeliveryDetailsModel> Handle(GetDeliveryDetails request, CancellationToken cancellationToken)
        {
        }
    }
}
