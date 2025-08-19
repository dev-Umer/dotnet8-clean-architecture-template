using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator) => _mediator = mediator;

    /// <summary>Returns all users.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetUsersQuery()));

    /// <summary>Creates a new user.</summary>
    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand cmd)
    {
        var created = await _mediator.Send(cmd);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Gets a user by id.</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        // For demo purposes use query handler result set from repo
        var users = await _mediator.Send(new GetUsersQuery());
        var u = users.FirstOrDefault(x => x.Id == id);
        return u is null ? NotFound() : Ok(u);
    }
}
