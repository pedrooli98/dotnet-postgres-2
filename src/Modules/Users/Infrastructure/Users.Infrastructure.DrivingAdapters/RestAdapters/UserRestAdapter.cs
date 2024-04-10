using Microsoft.AspNetCore.Mvc;
using Users.Application.Domain.Models;
using Users.Application.Ports.Driving.Users;

namespace Users.Infrastructure.DrivingAdapters.RestAdapters;

[ApiController]
[Route("api/v1/users")]
public class UserRestAdapter : ControllerBase
{
    [HttpGet]
    [Route("{id:guid:required}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id, [FromServices] IGetUser getUser)
    {
        var user = await getUser.Execute(id);

        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] User user, [FromServices] ICreateUser createUser)
    {
        var createdUser = await createUser.Execute(user);

        return CreatedAtAction(nameof(Get), new {id = createdUser.Id}, createdUser);
    }
}
