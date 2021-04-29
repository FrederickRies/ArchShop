using ArchShop.GenericHost.Models;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public class CreateDelivery : IRequest<DeliveryDetailsModel>
    {
    }
}
