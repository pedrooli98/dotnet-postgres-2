using Tasks.Application.Domain.Models;
using Tasks.Application.Ports.Driven;
using Tasks.Application.Ports.Driving.Tasks;

namespace Tasks.Application.UseCases.Tasks;

public class UpdateTask(ITaskRepository repository) : IUpdateTask
{
    public async Task<Todo?> Execute(Guid id, Todo t)
    {
        var updatedTask = await repository.Update(id, t);
        return updatedTask;
    }
}
