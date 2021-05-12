using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArchShop.GenericHost
{
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ILogger<StockController> _logger;
        private readonly IMediator _mediator;

        public StockController(ILogger<StockController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

    }
}
