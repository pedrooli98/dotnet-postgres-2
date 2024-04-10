using Users.Application.Domain.Models;
using Users.Application.Ports.Driven;
using Users.Application.Ports.Driving.Users;

namespace Users.Application.UseCases.Users;

public class UpdateUser(IUserRepository userRepository) : IUpdateUser
{
    public async Task<User?> Execute(Guid id, User user)
    {
        var updateUser = await userRepository.Update(id, user);
        return updateUser;
    }
}
