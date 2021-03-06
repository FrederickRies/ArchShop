using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class AccountDataLayer : BaseDataLayer<Account>
    {
        public AccountDataLayer(ArchShopContext context) 
            : base(context)
        {
        }

        public async Task<Account> GetAsync(AccountId accountId, CancellationToken cancellationToken)
        {
            var account = await Entities.Where(a => a.Id == accountId).SingleOrDefaultAsync(cancellationToken);
            return account ?? throw new NoDataException("The account is not found.");
        }
    }
}
