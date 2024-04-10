using Tasks.Application.Domain.Models;
using Tasks.Application.Ports.Driven;
using Tasks.Application.Ports.Driving.Tasks;

namespace Tasks.Application.UseCases.Tasks;

public class CreateTask(ITaskRepository repository) : ICreateTask
{
    public async Task<Todo> Execute(Todo t)
    {
        var createdTask = await repository.Create(t);
        return createdTask;
    }
}
