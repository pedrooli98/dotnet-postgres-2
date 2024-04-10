using Users.Application.Domain.Models;
using Users.Application.Ports.Driven;

namespace Users.Application.DrivenAdapters.Database;

public class UserPersistenceAdapters(UserContext context) : IUserRepository
{
    public async Task<User> Create(User t)
    {
        await context.Users.AddAsync(t);
        await context.SaveChangesAsync();

        return t;
    }

    public async Task<bool> Delete(Guid id)
    {
        var foundUser = await context.Users.FindAsync(id);
        if (foundUser is null)
            throw new NotImplementedException();
        
        context.Users.Remove(foundUser);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<User?> Get(Guid id)
    {
        var foundUser = await context.Users.FindAsync(id);
        if (foundUser is null)
            return null;
        
        return foundUser;
    }

    public async Task<User> Update(Guid id, User t)
    {
        var foundUser = await context.Users.FindAsync(id);
        if (foundUser is null)
            throw new NotImplementedException();

        foundUser.Username = t.Username;
        foundUser.Email = t.Email;
        foundUser.Password = t.Password;

        return t;
    }
}
