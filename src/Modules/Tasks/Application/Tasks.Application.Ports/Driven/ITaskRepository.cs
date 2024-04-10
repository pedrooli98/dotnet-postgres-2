using Tasks.Application.Domain.Models;

namespace Tasks.Application.Ports.Driven;

public interface ITaskRepository : IBaseRepository<Todo>
{
}
