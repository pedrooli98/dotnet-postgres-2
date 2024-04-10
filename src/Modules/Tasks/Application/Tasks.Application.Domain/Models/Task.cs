namespace Tasks.Application.Domain.Models;

public class MyTask
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set;} = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool Done { get; set; }
}
