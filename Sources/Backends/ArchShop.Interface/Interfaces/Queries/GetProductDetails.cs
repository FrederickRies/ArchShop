using ArchShop.Models;
using MediatR;

namespace ArchShop.Interfaces.Queries
{
    public class GetProductDetails : IRequest<ProductDetailsModel>
    {
    }
}
