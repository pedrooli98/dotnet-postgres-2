using Users.Application.Domain.Models;
using Users.Application.Ports.Driven;
using Users.Application.Ports.Driving.Users;

namespace Users.Application.UseCases.Users;

public class GetUser(IUserRepository userRepository) : IGetUser
{
    public async Task<User?> Execute(Guid id)
    {
        var foundUser = await userRepository.Get(id);
        return foundUser;
    }
}
