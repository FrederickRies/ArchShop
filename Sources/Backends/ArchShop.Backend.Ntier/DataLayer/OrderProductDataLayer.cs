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

        public async Task<OrderProduct?> GetAsync(OrderId orderId, ProductId productId, CancellationToken cancellationToken)
        {
            return await Entities
                .Where(op => op.OrderId == orderId && op.ProductId == productId)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
