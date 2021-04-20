using ArchShop.GenericHost.Models;
using MediatR;

namespace ArchShop.Interface.Commands
{
    public class CreateDelivery : IRequest<DeliveryDetailsModel>
    {
    }
}
