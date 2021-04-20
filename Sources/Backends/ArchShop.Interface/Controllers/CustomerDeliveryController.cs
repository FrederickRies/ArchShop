using ArchShop.GenericHost.Models;
using ArchShop.Interface.Commands;
using ArchShop.Interface.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ArchShop.GenericHost
{
    /// <summary>
    /// Controller responsible for handling all requests related to the deliveries.
    /// </summary>
    /// <remarks>
    /// All request are scoped to the currently logged customer.
    /// </remarks>
    [ApiController]
    public class CustomerDeliveryController : ControllerBase
    {
        private readonly ILogger<CustomerDeliveryController> _logger;
        private readonly IMediator _mediator;

        public CustomerDeliveryController(ILogger<CustomerDeliveryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Create a delivery.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(DeliveryDetailsModel), Status200OK)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<DeliveryDetailsModel> CreateDeliveryAsync(CancellationToken cancellationToken)
        {
            var command = new CreateDelivery();
            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Get all details of a specific delivery.
        /// </summary>
        /// <param name="orderId">The delivery identifier we want to know the details of.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpGet("{deliveryId:guid}")]
        [ProducesResponseType(typeof(DeliveryDetailsModel), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<DeliveryDetailsModel> GetDeliveryAsync(Guid deliveryId, CancellationToken cancellationToken)
        {
            var query = new GetDeliveryDetails();
            return await _mediator.Send(query, cancellationToken);
        }
    }
}
