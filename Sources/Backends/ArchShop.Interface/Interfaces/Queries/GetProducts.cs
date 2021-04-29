using ArchShop.Models;
using MediatR;
using System.Collections.Generic;

namespace ArchShop.Interfaces.Queries
{
    public class GetProducts : IRequest<IEnumerable<ProductListModel>>
    {
    }
}
