using Tasks.Application.Domain.Models;
using Tasks.Application.Ports.Driven;
using Tasks.Application.Ports.Driving.Tasks;

namespace Tasks.Application.UseCases.Tasks;

public class GetTask(ITaskRepository repository) : IGetTask
{
    public Task<Todo?> Execute(Guid id)
    {   
        var foundTask = repository.Get(id);
        return foundTask;
    }
}
