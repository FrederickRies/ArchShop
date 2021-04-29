using ArchShop.Data;
using ArchShop.ValueObjects;
using System;
using System.Threading.Tasks;

namespace ArchShop.Business
{
    public class AccountLogic
    {
        public Task<Account> CreateAccountAsync(string firstName, string lastName)
        {
            var account = new Account(
                AccountId.New(),
                firstName,
                lastName);
            return Task.FromResult(account);
        }

        public Task<Account?> GetAccountAsync(AccountId accountId)
        {
            return Task.FromResult((Account?)null);
        }
    }
}
