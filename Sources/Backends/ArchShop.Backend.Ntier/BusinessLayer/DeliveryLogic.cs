using ArchShop.Data;
using ArchShop.DataLayer;
using ArchShop.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Business
{
    public class DeliveryLogic
    {
        protected readonly DeliveryDataLayer _deliveryDataLayer;

        public DeliveryLogic(DeliveryDataLayer deliveryDataLayer)
        {
            _deliveryDataLayer = deliveryDataLayer;
        }

        public Task<Delivery> CreateAsync(OrderId orderId, AddressId addressId, DateTimeOffset deliveryDate)
        {
            return Task.FromResult(_deliveryDataLayer.Add(
                new Delivery(
                    DeliveryId.New,
                    orderId,
                    addressId,
                    deliveryDate)));
        }

        public async Task RemoveAsync(DeliveryId deliveryId, CancellationToken cancelationToken)
        {
            _deliveryDataLayer.Remove(await _deliveryDataLayer.GetAsync(deliveryId, cancelationToken));
        }
    }
}
