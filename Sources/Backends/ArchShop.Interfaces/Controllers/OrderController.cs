using ArchShop.Models;
using ArchShop.Interfaces.Commands;
using ArchShop.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using ArchShop.ValueObjects;

namespace ArchShop.GenericHost
{
    /// <summary>
    /// Controller responsible for handling all requests related to customers orders.
    /// </summary>
    /// <remarks>
    /// All request are scoped to the currently logged customer.
    /// </remarks>
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ProblemDetails), Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), Status403Forbidden)]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Obtain a new instance of the <see cref="OrderController" /> controller.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all customer orders
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), Status200OK)]
        public async Task<IEnumerable<OrderListModel>> GetCustomerOrdersAsync(CancellationToken cancellationToken)
        {
            var query = new GetOrders();
            return await _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Create a new Customer order.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(OrderDetailsModel), Status200OK)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<IActionResult> CreateCustomerCommandAsync(CancellationToken cancellationToken)
        {
            var command = new CreateOrder();
            await _mediator.Send(command, cancellationToken);
            return new OkResult();
        }

        /// <summary>
        /// Get all details of a specific customer order.
        /// </summary>
        /// <param name="orderId">The order identifier we want to know the details of.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpGet("{orderId:guid}")]
        [ProducesResponseType(typeof(OrderDetailsModel), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<OrderDetailsModel> GetCustomerCommandAsync(Guid orderId, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetails();
            return await _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Add a product item to a customer order.
        /// </summary>
        /// <remarks>
        /// If the customer order has been paid, a 400 (Bad Request) response status code is returned.
        /// </remarks>
        /// <param name="orderId">The order identifier whose product must be added.</param>
        /// <param name="productId">The product identifier that must be added to the order.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPost("{orderId:guid}/product/{productId:guid}")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<IActionResult> AddProductToCustomerCommandAsync(Guid orderId, Guid productId, int count, CancellationToken cancellationToken)
        {
            var command = new AddProductToOrder(new OrderId(orderId), new ProductId(productId), count);
            await _mediator.Send(command, cancellationToken);
            return new NoContentResult();
        }

        /// <summary>
        /// Remove a product item from a customer order.
        /// </summary>
        /// <remarks>
        /// If the customer order has been paid, a 400 (Bad Request) response status code is returned.
        /// </remarks>
        /// <param name="orderId">The order identifier whose product must be removed.</param>
        /// <param name="productId">The product identifier that must be removed from the order.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpDelete("{orderId:guid}/product/{productId}")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<IActionResult> RemoveProductFromCustomerOrderAsync(Guid orderId, Guid productId, CancellationToken cancellationToken)
        {
            var command = new RemoveProductFromOrder(new OrderId(orderId), new ProductId(productId));
            await _mediator.Send(command, cancellationToken);
            return new NoContentResult();
        }

        /// <summary>
        /// Pay a customer order and proceed to the delivery process.
        /// </summary>
        /// <remarks>
        /// If the customer order has been paid, a 400 (Bad Request) response status code is returned.
        /// </remarks>
        /// <param name="orderId">The order identifier that needs to be paid.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPost("{orderId:guid}/pay")]
        [ProducesResponseType(Status202Accepted)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<IActionResult> PayCustomerOrderAsync(Guid orderId, CancellationToken cancellationToken)
        {
            var command = new PayOrder(new OrderId(orderId));
            await _mediator.Send(command, cancellationToken);
            return new AcceptedResult();
        }

        /// <summary>
        /// Delete a customer order.
        /// </summary>
        /// <remarks>
        /// If the customer order has been paid, a 400 (Bad Request) response status code is returned.
        /// </remarks>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpDelete("{orderId:guid}")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<IActionResult> RemoveCustomerCommandAsync(Guid orderId, CancellationToken cancellationToken)
        {
            var command = new DeleteOrder(new OrderId(orderId));
            await _mediator.Send(command, cancellationToken);
            return new NoContentResult();
        }
    }
}
