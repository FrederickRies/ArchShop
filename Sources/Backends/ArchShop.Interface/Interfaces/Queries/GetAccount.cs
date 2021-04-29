using ArchShop.Models;
using MediatR;
using System;

namespace ArchShop.Interfaces.Queries
{
    public record GetAccount : IRequest<AccountDetailsModel>
    {
        public Guid AccountId { get; }

        public GetAccount(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
