using ArchShop.Models;
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

namespace ArchShop.GenericHost
{
    /// <summary>
    /// Controller responsible for handling all requests related to the product catalog.
    /// </summary>
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly IMediator _mediator;

        public CatalogController(ILogger<CatalogController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all product items from the catalog
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductListModel>), Status200OK)]
        public async Task<IEnumerable<ProductListModel>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var query = new GetProducts();
            return await _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Get the details of a specific product item.
        /// </summary>
        /// <param name="productId">The product identifier we want to know the details of.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        [HttpGet("{productId:guid}")]
        [ProducesResponseType(typeof(ProductDetailsModel), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ProductDetailsModel> GetProductDetailsAsync(Guid productId, CancellationToken cancellationToken)
        {
            var query = new GetProductDetails();
            return await _mediator.Send(query, cancellationToken);
        }
    }
}
