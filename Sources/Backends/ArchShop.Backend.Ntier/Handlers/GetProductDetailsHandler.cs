using ArchShop.Business;
using ArchShop.Interfaces.Queries;
using ArchShop.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Handlers
{
    public class GetProductDetailsHandler : IRequestHandler<GetProductDetails, ProductDetailsModel>
    {
        private readonly AccountLogic _accountLogic;

        public GetProductDetailsHandler(AccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public async Task<ProductDetailsModel> Handle(GetProductDetails request, CancellationToken cancellationToken)
        {
        }
    }
}
