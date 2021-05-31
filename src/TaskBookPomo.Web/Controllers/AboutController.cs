using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBookPomo.Common.Helpers;
using TaskBookPomo.Infrastructure.Queries;

namespace TaskBookPomo.Web.Controllers
{
    [Route(template: "api/v1/about")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<AboutInfo>> GetAboutInfo() =>
            await _mediator.Send(request: new GetAboutInfo.Query());
    }
}