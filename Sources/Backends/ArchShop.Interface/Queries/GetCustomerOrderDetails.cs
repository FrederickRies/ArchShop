using ArchShop.GenericHost.Models;
using MediatR;

namespace ArchShop.Interface.Queries
{
    public class GetCustomerOrderDetails : IRequest<CustomerOrderDetailsModel>
    {
    }
}
