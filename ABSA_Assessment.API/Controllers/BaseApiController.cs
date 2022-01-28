using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ABSA_Assessment.API.Controllers
{
    /// <summary>
    /// The controller base.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// Gets the mediator.
        /// </summary>
        /// <value>
        /// The mediator.
        /// </value>
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
