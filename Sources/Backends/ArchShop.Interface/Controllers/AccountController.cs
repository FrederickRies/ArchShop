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
    /// Controller responsible for handling all requests related to the account.
    /// </summary>
    /// <remarks>
    /// All request are related to the currently logged customer.
    /// </remarks>
    [ApiController]
    [ProducesResponseType(typeof(ProblemDetails), Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), Status403Forbidden)]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// Obtain a new instance of the <see cref="AccountController" /> controller.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(AccountDetailsModel), Status200OK)]
        public async Task<AccountDetailsModel> GetAsync(CancellationToken cancellationToken)
        {
            var query = new GetAccount();
            return await _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(AccountDetailsModel), Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<AccountDetailsModel> RegisterAsync(CancellationToken cancellationToken)
        {
            var query = new RegisterAccount();
            return await _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Get all details of a specific customer order.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpPut("address")]
        [ProducesResponseType(typeof(AddressModel), Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<AddressModel> AddAddressAsync(CancellationToken cancellationToken)
        {
            var command = new AddAddressToAccount();
            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Get all details of a specific customer order.
        /// </summary>
        /// <param name="addressId">The address identifier we want to remove from the account.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpDelete("address/{addressId:guid}")]
        [ProducesResponseType(Status204NoContent)]
        public async Task<IActionResult> RemoveAddressAsync(Guid addressId, CancellationToken cancellationToken)
        {
            var command = new RemoveAddressFromAccount();
            await _mediator.Send(command, cancellationToken);
            return new NoContentResult();
        }
    }
}
