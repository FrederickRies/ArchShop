using ArchShop.Models;
using MediatR;

namespace ArchShop.Interfaces.Queries
{
    public class GetAccount : IRequest<AccountDetailsModel>
    {
    }
}
