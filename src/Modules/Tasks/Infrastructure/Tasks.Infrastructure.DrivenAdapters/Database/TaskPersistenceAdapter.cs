using Tasks.Application.Domain.Models;
using Tasks.Application.Ports.Driven;

namespace Tasks.Infrastructure.DrivenAdapters.Database;

public class TaskPersistenceAdapter(TaskContext context) : ITaskRepository
{
    public async Task<Todo> Create(Todo t)
    {
        await context.Tasks.AddAsync(t);
        await context.SaveChangesAsync();

        return t;
    }

    public async Task<bool> Delete(Guid id)
    {
        var foundTask = await context.Tasks.FindAsync(id);
        if (foundTask is null)
            throw new NotImplementedException();
        
        context.Tasks.Remove(foundTask);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<Todo?> Get(Guid id)
    {
        var foundTask = await context.Tasks.FindAsync(id);
        if (foundTask is null)
            return null;
        
        return foundTask;
        throw new NotImplementedException();
    }

    public async Task<Todo> Update(Guid id, Todo t)
    {
        var foundTask = await context.Tasks.FindAsync(id);
        if (foundTask is null)
            throw new NotImplementedException();

        foundTask.Title = t.Title;
        foundTask.Content = t.Content;
        foundTask.Done = t.Done;
        
        await context.SaveChangesAsync();

        return foundTask;

    }
}
