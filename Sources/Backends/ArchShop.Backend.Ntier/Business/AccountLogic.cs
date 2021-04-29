using ArchShop.Data;
using System;
using System.Threading.Tasks;

namespace ArchShop.Business
{
    public class AccountLogic
    {
        public Task<Account> CreateAccountAsync(string firstName, string lastName)
        {
            var account = new Account(
                Guid.NewGuid(),
                firstName,
                lastName);
            return Task.FromResult(account);
        }
    }
}
