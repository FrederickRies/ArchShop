using ArchShop.Business;
using ArchShop.Interfaces.Queries;
using ArchShop.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProducts, IEnumerable<ProductListModel>>
    {
        private readonly AccountLogic _accountLogic;

        public GetProductsHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<IEnumerable<ProductListModel>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
        }
    }
}
