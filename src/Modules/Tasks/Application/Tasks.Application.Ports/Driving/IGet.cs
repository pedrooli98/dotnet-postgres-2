namespace Tasks.Application.Ports.Driving;

public interface IGet<T> where T : class
{
    Task<T?> Execute(Guid id);
}