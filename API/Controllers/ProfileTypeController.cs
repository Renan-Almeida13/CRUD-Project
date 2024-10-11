using Domain.Entities.ProfileType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/profile-type")]
    [ApiController]
    public class ProfileTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _mediator.Send(new ListProfileTypeQuery());
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
