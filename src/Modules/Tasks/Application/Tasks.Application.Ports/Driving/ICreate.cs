namespace Tasks.Application.Ports.Driving;

public interface ICreate<T> where T : class
{
    Task<T> Execute(T t);
}