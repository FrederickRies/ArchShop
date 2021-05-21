using ArchShop.Models;
using ArchShop.ValueObjects;
using MediatR;

namespace ArchShop.Interfaces.Queries
{
    public record GetAccount() : IRequest<AccountDetailsModel>;
}
