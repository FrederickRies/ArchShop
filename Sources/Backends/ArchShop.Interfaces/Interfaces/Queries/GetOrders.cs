using ArchShop.Models;
using MediatR;
using System.Collections.Generic;

namespace ArchShop.Interfaces.Queries
{
    public class GetOrders : IRequest<IEnumerable<OrderListModel>>
    {
    }
}
