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
        protected readonly AddressDataLayer _addressDataLayer;

        public AccountLogic(AccountDataLayer accountDataLayer, AddressDataLayer addressDataLayer)
        {
            _accountDataLayer = accountDataLayer;
            _addressDataLayer = addressDataLayer;
        }

        public Task<Account> CreateAccountAsync(string firstName, string lastName)
        {
            return Task.FromResult(_accountDataLayer.Add(
                new Account(
                    AccountId.New,
                    firstName,
                    lastName)));
        }

        public async Task<Account> GetAccountAsync(AccountId accountId, CancellationToken cancelationToken)
        {
            return await _accountDataLayer.GetAsync(accountId, cancelationToken);
        }

        public async Task<Address> CreateAddressAsync(AccountId accountId, string street, string city, CancellationToken cancelationToken)
        {
            Account account = await _accountDataLayer.GetAsync(accountId, cancelationToken);
            return _addressDataLayer.Add(
                new Address(
                    AddressId.New,
                    account.Id,
                    street,
                    city));
        }

        public async Task RemoveAddressAsync(AccountId accountId, AddressId addressId, CancellationToken cancelationToken)
        {
            Account account = await _accountDataLayer.GetAsync(accountId, cancelationToken);
            Address address = await _addressDataLayer.GetAsync(addressId, cancelationToken);
            _addressDataLayer.Remove(address);
        }
    }
}
