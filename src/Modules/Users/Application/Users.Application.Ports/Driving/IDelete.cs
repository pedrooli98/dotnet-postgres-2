namespace Users.Application.Ports.Driving;

public interface IDelete<T> where T : class
{
    Task<bool> Execute(Guid id);
}
