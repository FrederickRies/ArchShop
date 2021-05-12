using ArchShop.Models;
using MediatR;

namespace ArchShop.Interfaces.Queries
{
    public class GetOrderDetails : IRequest<OrderDetailsModel>
    {
    }
}
