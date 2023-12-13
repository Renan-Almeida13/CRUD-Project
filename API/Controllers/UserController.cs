using Domain.Entities.User.Commands;
using Domain.Entities.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new ListUserQuery());
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditUserCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
