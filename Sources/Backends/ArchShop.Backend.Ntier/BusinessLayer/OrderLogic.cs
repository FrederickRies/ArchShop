using ArchShop.Data;
using System.Threading.Tasks;

namespace ArchShop.Business
{
    public class OrderLogic
    {
        public Task<Order> CreateOrderAsync()
        {
            return Task.FromResult(account);
        }
    }
}
