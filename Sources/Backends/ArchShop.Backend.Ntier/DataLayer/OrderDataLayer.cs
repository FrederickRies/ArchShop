using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class OrderDataLayer : BaseDataLayer<Order>
    {
        public OrderDataLayer(ArchShopContext context)
            : base(context)
        {
        }

        public async Task<Order> GetAsync(OrderId orderId, CancellationToken cancellationToken)
        {
            var order = await Entities.Where(o => o.Id == orderId).SingleOrDefaultAsync(cancellationToken);
            return order ?? throw new NoDataException("The order is not found.");
        }
    }
}
