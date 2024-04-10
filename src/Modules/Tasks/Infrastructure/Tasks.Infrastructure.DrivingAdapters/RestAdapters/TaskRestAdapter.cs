using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Domain.Models;
using Tasks.Application.Ports.Driving.Tasks;
using Tasks.Infrastructure.DrivenAdapters.MassTransit.Contracts;

namespace Tasks.Infrastructure.DrivingAdapters.RestAdapters;

[ApiController]
[Route("api/v1/tasks")]
public class TaskRestAdapter : ControllerBase
{
    [HttpGet]
    [Route("{id:guid:required}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] Guid id, [FromServices] IGetTask getTask)
    {
        var task = await getTask.Execute(id);
        return task is not null ? Ok(task) : NotFound();
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Todo task, [FromServices] ICreateTask createTask, [FromServices] IPublishEndpoint publishEndpoint)
    {
        var createdTask = await createTask.Execute(task);
        await publishEndpoint.Publish<TaskSubmmited>(new() { UserId = createdTask.Id });

        return CreatedAtAction(nameof(Get), new { id = createdTask.Id }, createdTask);
    }
}
