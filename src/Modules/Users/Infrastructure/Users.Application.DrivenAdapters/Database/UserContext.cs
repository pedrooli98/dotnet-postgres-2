using Microsoft.EntityFrameworkCore;
using Users.Application.Domain.Models;

namespace Users.Application.DrivenAdapters.Database;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData
        (
            new User { Id = Guid.NewGuid(), Username = "John", Email = "a3h9Q@example.com", Password = "123456" },
            new User { Id = Guid.NewGuid(), Username = "Jane", Email = "a3h9Q@example.com", Password = "123456" }
        );
    }
}
