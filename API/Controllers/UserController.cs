using Domain.Commons;
using Domain.Entities.User.Commands;
using Domain.Entities.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[Route("api/[controller]")]
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
        return HandleResponse(response);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await _mediator.Send(new GetByIdUserQuery { Id = id });
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddUserCommand request)
    {
        var response = await _mediator.Send(request);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync([FromBody] EditUserCommand request)
    {
        var response = await _mediator.Send(request);
        return HandleResponse(response);
    }

    [HttpPut("Remove")]
    public async Task<IActionResult> RemoveAsync([FromBody] RemoveUserCommand request)
    {
        var response = await _mediator.Send(request);
        return HandleResponse(response);
    }

    private IActionResult HandleResponse(Response response)
    {
        return response.StatusCode switch
        {
            HttpStatusCode.OK => Ok(response.Data),
            HttpStatusCode.NotFound => NotFound(response.Errors),
            HttpStatusCode.BadRequest => BadRequest(response.Errors),
            _ => StatusCode((int)response.StatusCode, response.Errors)
        };
    }
}
