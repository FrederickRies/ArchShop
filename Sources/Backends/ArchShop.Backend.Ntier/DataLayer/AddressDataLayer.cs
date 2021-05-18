using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class AddressDataLayer : BaseDataLayer<Address>
    {
        public AddressDataLayer(ArchShopContext context)
            : base(context)
        {
        }

        public async Task<Address> GetAsync(AddressId addressId, CancellationToken cancellationToken)
        {
            var address = await Entities.Where(a => a.Id == addressId).SingleOrDefaultAsync(cancellationToken); 
            return address ?? throw new NoDataException("The address is not found.");
        }
    }
}
