using Tasks.Application.Ports.Driven;
using Tasks.Application.Ports.Driving.Tasks;

namespace Tasks.Application.UseCases.Tasks;

public class DeleteTask(ITaskRepository repository) : IDeleteTask
{
    public async Task<bool> Execute(Guid id)
    {
        var deletedTask = await repository.Delete(id);
        return deletedTask;
    }
}
