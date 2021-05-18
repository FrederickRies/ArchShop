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
        private readonly DeliveryLogic _deliveryLogic;

        public CreateDeliveryHandler(DeliveryLogic deliveryLogic)
        {
            _deliveryLogic = deliveryLogic;
        }

        public async Task<DeliveryDetailsModel> Handle(CreateDelivery request, CancellationToken cancellationToken)
        {
            var delivery = await _deliveryLogic.CreateAsync(request.OrderId, request.AddressId, request.DeliveryDate);
            return new DeliveryDetailsModel();
        }
    }
}
