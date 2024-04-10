using Users.Application.Ports.Driven;
using Users.Application.Ports.Driving.Users;

namespace Users.Application.UseCases.Users;

public class DeleteUser(IUserRepository userRepository) : IDeleteUser
{
    public async Task<bool> Execute(Guid id)
    {
        var deletedUser = await userRepository.Delete(id);
        return deletedUser;
    }
}
