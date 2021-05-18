using ArchShop.Models;
using ArchShop.ValueObjects;
using MediatR;
using System;

namespace ArchShop.Interfaces.Commands
{
    public record CreateDelivery(OrderId OrderId, AddressId AddressId, DateTimeOffset DeliveryDate)
        : IRequest<DeliveryDetailsModel>;
}
