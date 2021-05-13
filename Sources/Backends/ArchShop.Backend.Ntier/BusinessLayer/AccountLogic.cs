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
                AccountId.New,
                firstName,
                lastName);
            return Task.FromResult(account);
        }

        public Task<Account> GetAccountAsync(AccountId accountId)
        {
            Account? account = null;
            if (account == null)
            {
                throw new InvalidOperationException("The account is not found.");
            }
            return Task.FromResult(account);
        }

        public async Task<Address> CreateAddressAsync(AccountId accountId, string street, string city)
        {
            var account = await GetAccountAsync(accountId);
            var address = new Address(
                AddressId.New,
                account.Id,
                street,
                city);
            return address;
        }

        public async Task RemoveAddressAsync(AccountId accountId, AddressId addressId)
        {
            var account = await GetAccountAsync(accountId);
        }
    }
}
