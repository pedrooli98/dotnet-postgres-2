using Microsoft.EntityFrameworkCore;
using Tasks.Application.Domain.Models;

namespace Tasks.Infrastructure.DrivenAdapters.Database;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    public DbSet<Todo> Tasks { get; set; }
}
