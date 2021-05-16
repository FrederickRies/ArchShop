using ArchShop.Data;
using ArchShop.DataLayer;
using ArchShop.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Business
{
    public class AccountLogic
    {
        protected readonly AccountDataLayer _accountDataLayer;

        public AccountLogic(AccountDataLayer accountDataLayer)
        {
            _accountDataLayer = accountDataLayer;
        }

        public Task<Account> CreateAccountAsync(string firstName, string lastName)
        {
            var account = new Account(
                AccountId.New,
                firstName,
                lastName);
            return Task.FromResult(account);
        }

        public async Task<Account> GetAccountAsync(AccountId accountId, CancellationToken cancelationToken)
        {
            Account? account = await _accountDataLayer.GetByIdAsync(accountId, cancelationToken);
            if (account == null)
            {
                throw new InvalidOperationException("The account is not found.");
            }
            return account;
        }

        public async Task<Address> CreateAddressAsync(AccountId accountId, string street, string city, CancellationToken cancelationToken)
        {
            Account? account = await _accountDataLayer.GetByIdAsync(accountId, cancelationToken);
            if (account == null)
            {
                throw new InvalidOperationException("The account is not found.");
            }
            var address = new Address(
                AddressId.New,
                account.Id,
                street,
                city);
            return address;
        }

        public async Task RemoveAddressAsync(AccountId accountId, AddressId addressId, CancellationToken cancelationToken)
        {
            Account? account = await _accountDataLayer.GetByIdAsync(accountId, cancelationToken);
            if (account == null)
            {
                throw new InvalidOperationException("The account is not found.");
            }
        }
    }
}
