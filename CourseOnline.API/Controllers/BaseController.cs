using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _meaditor;

        protected IMediator Mediator => _meaditor ??= HttpContext.RequestServices.GetService<IMediator>(); 
    }
}

