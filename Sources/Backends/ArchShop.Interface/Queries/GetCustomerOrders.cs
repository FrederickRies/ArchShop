using ArchShop.GenericHost.Models;
using MediatR;
using System.Collections.Generic;

namespace ArchShop.Interface.Queries
{
    public class GetCustomerOrders : IRequest<IEnumerable<OrderModel>>
    {
    }
}
