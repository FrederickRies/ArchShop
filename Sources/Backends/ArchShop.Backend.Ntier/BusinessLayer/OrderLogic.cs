using ArchShop.Data;
using ArchShop.DataLayer;
using ArchShop.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.Business
{
    public class OrderLogic
    {
        protected readonly OrderDataLayer _orderDataLayer;
        protected readonly ProductDataLayer _productDataLayer;
        protected readonly OrderProductDataLayer _orderProductDataLayer;

        public OrderLogic(
            OrderDataLayer orderDataLayer,
            ProductDataLayer productDataLayer,
            OrderProductDataLayer orderProductDataLayer)
        {
            _orderDataLayer = orderDataLayer;
            _productDataLayer = productDataLayer;
            _orderProductDataLayer = orderProductDataLayer;
        }

        public Task<Order> CreateOrderAsync(AccountId accountId)
        {
            return Task.FromResult(_orderDataLayer.Add(
                new Order(
                    OrderId.New,
                    OrderStatus.Basket,
                    accountId,
                    DateTimeOffset.UtcNow)));
        }

        public async Task<Order> GetOrderAsync(OrderId orderId, CancellationToken cancelationToken)
        {
            return await _orderDataLayer.GetAsync(orderId, cancelationToken);
        }

        public async Task AddProductAsync(OrderId orderId, ProductId productId, int count, CancellationToken cancelationToken)
        {
            Order order = await _orderDataLayer.GetAsync(orderId, cancelationToken);
            Product product = await _productDataLayer.GetAsync(productId, cancelationToken);

            _orderProductDataLayer.Add(
                new OrderProduct(
                    order.Id,
                    product.Id,
                    count));
        }

        public async Task RemoveProductAsync(OrderId orderId, ProductId productId, CancellationToken cancelationToken)
        {
            OrderProduct orderProduct = await _orderProductDataLayer.GetAsync(orderId, productId, cancelationToken);
            _orderProductDataLayer.Remove(orderProduct);
        }

        public async Task RemoveAsync(OrderId orderId, CancellationToken cancelationToken)
        {
            _orderDataLayer.Remove(await _orderDataLayer.GetAsync(orderId, cancelationToken));
        }
    }
}
