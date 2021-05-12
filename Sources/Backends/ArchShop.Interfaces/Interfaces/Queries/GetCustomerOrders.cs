using ArchShop.Models;
using MediatR;
using System.Collections.Generic;

namespace ArchShop.Interfaces.Queries
{
    public class GetCustomerOrders : IRequest<IEnumerable<OrderListModel>>
    {
    }
}
