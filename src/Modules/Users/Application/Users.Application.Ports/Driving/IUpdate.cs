namespace Users.Application.Ports.Driving;

public interface IUpdate<T> where T : class
{
    Task<T?> Execute(Guid id, T t);
}