using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class AccountDataLayer
    {
        private readonly ArchShopContext _context;

        public AccountDataLayer(ArchShopContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetByIdAsync(AccountId accountId, CancellationToken cancellationToken)
        {
            return await _context.Accounts.Where(a => a.Id == accountId).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
