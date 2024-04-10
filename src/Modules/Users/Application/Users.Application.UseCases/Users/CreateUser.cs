using Users.Application.Domain.Models;
using Users.Application.Ports.Driven;
using Users.Application.Ports.Driving.Users;

namespace Users.Application.UseCases.Users;

public class CreateUser(IUserRepository userRepository) : ICreateUser
{
    public async Task<User> Execute(User user)
    {
        var createdUser = await userRepository.Create(user);

        return user;
    }
}
