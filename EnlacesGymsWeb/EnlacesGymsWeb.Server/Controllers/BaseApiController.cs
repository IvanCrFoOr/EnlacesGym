﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnlacesGymsWeb.Server.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();        
    }
}
