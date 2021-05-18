using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class OrderProductDataLayer : BaseDataLayer<OrderProduct>
    {
        public OrderProductDataLayer(ArchShopContext context)
            : base(context)
        {
        }

        protected async Task<OrderProduct?> RetrieveAsync(OrderId orderId, ProductId productId, CancellationToken cancellationToken)
        {
            return await Entities
                .Where(op => op.OrderId == orderId && op.ProductId == productId)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<OrderProduct> GetAsync(OrderId orderId, ProductId productId, CancellationToken cancellationToken)
        {
            var orderProduct = await RetrieveAsync(orderId, productId, cancellationToken);
            return orderProduct ?? throw new NoDataException("The product order is not found.");
        }

        public async Task<OrderProduct?> SearchAsync(OrderId orderId, ProductId productId, CancellationToken cancellationToken)
        {
            return await RetrieveAsync(orderId, productId, cancellationToken);
        }
    }
}
