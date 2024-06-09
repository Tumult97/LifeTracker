using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;

namespace LifeTracker.Infrastructure.DataManagers.Users;

public class UserCommandManager(DatabaseContext context) : IUserCommandManager
{
    public void Create(UserEntity user)
    {
        context.Users.Add(user);
    }  
    
    public void Update(UserEntity user)
    {
        context.Users.Update(user);
    }
    
    public void Delete(UserEntity user)
    {
        context.Users.Remove(user);
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}