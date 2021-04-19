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
    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly IMediator _mediator;

        public DeliveryController(ILogger<DeliveryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
    }
}
