using ArchShop.Models;
using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Queries
{
    public record GetDeliveryDetails(DeliveryId DeliveryId) : IRequest<DeliveryDetailsModel>;
}
