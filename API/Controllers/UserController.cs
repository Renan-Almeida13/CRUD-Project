using Domain.Entities.User.Commands;
using Domain.Entities.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> ListAsync()
        {
            var response = await _mediator.Send(new ListUserQuery());

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            return StatusCode((int)response.StatusCode, response.Errors);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetByIdUserQuery { Id = id });

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            return StatusCode((int)response.StatusCode, response.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserCommand request)
        {
            var response = await _mediator.Send(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return BadRequest(response.Errors);
            }

            return StatusCode((int)response.StatusCode, response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> EditAsync(EditUserCommand request)
        {
            var response = await _mediator.Send(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            return StatusCode((int)response.StatusCode, response.Errors);
        }

        [HttpPut("Remove")]
        public async Task<IActionResult> RemoveAsync(RemoveUserCommand request)
        {
            var response = await _mediator.Send(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Errors);
            }

            return StatusCode((int)response.StatusCode, response.Errors);
        }
    }
}
