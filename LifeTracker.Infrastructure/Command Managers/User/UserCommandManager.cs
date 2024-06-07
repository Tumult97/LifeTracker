using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;

namespace LifeTracker.Infrastructure.Command_Managers.User;

public class UserCommandManager(DatabaseContext context) : IUserCommandManager
{
    public void CreateAsync(UserEntity user)
    {
        context.users.Add(user);
    }   

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}