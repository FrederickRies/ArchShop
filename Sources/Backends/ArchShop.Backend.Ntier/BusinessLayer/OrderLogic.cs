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
            Order? order = await _orderDataLayer.GetAsync(orderId, cancelationToken);
            if (order == null)
            {
                throw new InvalidOperationException("The order is not found.");
            }
            return order;
        }

        public async Task AddProductAsync(OrderId orderId, ProductId productId, int count, CancellationToken cancelationToken)
        {
            Order? order = await _orderDataLayer.GetAsync(orderId, cancelationToken);
            if (order == null)
            {
                throw new InvalidOperationException("The order is not found.");
            }
            Product? product = await _productDataLayer.GetAsync(productId, cancelationToken);
            if (product == null)
            {
                throw new InvalidOperationException("The product is not found.");
            }
            _orderProductDataLayer.Add(
                new OrderProduct(
                    order.Id,
                    product.Id,
                    count));
        }

        public async Task RemoveProductAsync(OrderId orderId, ProductId productId, CancellationToken cancelationToken)
        {
            OrderProduct? orderProduct = await _orderProductDataLayer.GetAsync(orderId, productId, cancelationToken);
            if (orderProduct == null)
            {
                throw new InvalidOperationException("The product order is not found.");
            }
            _orderProductDataLayer.Remove(orderProduct);
        }

        public async Task RemoveAsync(OrderId orderId, CancellationToken cancelationToken)
        {
            Order? order = await _orderDataLayer.GetAsync(orderId, cancelationToken);
            if (order == null)
            {
                throw new InvalidOperationException("The order is not found.");
            }
            _orderDataLayer.Remove(order);
        }
    }
}
