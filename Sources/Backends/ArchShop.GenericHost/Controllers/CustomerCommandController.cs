using ArchShop.GenericHost.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ArchShop.GenericHost
{
    [ApiController]
    public class CustomerCommandController : ControllerBase
    {
        private readonly ILogger<CustomerCommandController> _logger;
        private readonly IMediator _mediator;

        public CustomerCommandController(ILogger<CustomerCommandController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), Status200OK)]
        public async Task<IEnumerable<CommandModel>> GetCustomerCommandsAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send<IEnumerable<CommandModel>>(cancellationToken);
        }

        [HttpPut]

        [ProducesResponseType(typeof(string), Status200OK)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<CommandModel> CreateCustomerCommandAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send<IEnumerable<CommandModel>>(cancellationToken);
        }

        [HttpGet("{commandeId:guid}/product/{productId}")]

        [ProducesResponseType(typeof(string), Status204NoContent)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<CommandModel> AddProductOnCustomerCommandAsync(Guid commandId, CancellationToken cancellationToken)
        {
            return await _mediator.Send<IEnumerable<CommandModel>>(cancellationToken);
        }

        [HttpDelete("{commandeId:guid}/product/{productId}")]

        [ProducesResponseType(typeof(string), Status204NoContent)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<CommandModel> RemoveProductOnCustomerCommandAsync(Guid commandId, CancellationToken cancellationToken)
        {
            return await _mediator.Send<IEnumerable<CommandModel>>(cancellationToken);
        }

        [HttpPost("{commandeId:guid}/pay")]
        [ProducesResponseType(typeof(string), Status204NoContent)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<IActionResult> PayCustomerCommandAsync(Guid commandId, CancellationToken cancellationToken)
        {
            await _mediator.Send<IEnumerable<CommandModel>>(cancellationToken);
            return new NoContentResult();
        }

        [HttpDelete("{commandeId:guid}")]
        [ProducesResponseType(typeof(string), Status204NoContent)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<IActionResult> RemoveCustomerCommandAsync(Guid commandId, CancellationToken cancellationToken)
        {
            await _mediator.Send<IEnumerable<CommandModel>>(cancellationToken);
            return new NoContentResult();
        }
    }
}
