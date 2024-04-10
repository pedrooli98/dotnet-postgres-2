using Users.Application.Domain.Models;

namespace Users.Application.Ports.Driven;

public interface IUserRepository : IBaseRepository<User>
{
}
