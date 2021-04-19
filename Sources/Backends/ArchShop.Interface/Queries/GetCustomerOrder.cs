using ArchShop.GenericHost.Models;
using MediatR;

namespace ArchShop.Interface.Queries
{
    public class GetCustomerOrder : IRequest<CustomerOrderModel>
    {
    }
}
