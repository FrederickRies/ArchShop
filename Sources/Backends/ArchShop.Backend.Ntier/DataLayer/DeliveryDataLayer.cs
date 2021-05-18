using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class DeliveryDataLayer : BaseDataLayer<Delivery>
    {
        public DeliveryDataLayer(ArchShopContext context)
            : base(context)
        {
        }

        public async Task<Delivery?> GetAsync(DeliveryId deliveryId, CancellationToken cancellationToken)
        {
            var delivery = await Entities.Where(d => d.Id == deliveryId).SingleOrDefaultAsync(cancellationToken);
            return delivery ?? throw new NoDataException("The delivery is not found.");
        }
    }
}
