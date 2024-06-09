using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Users;

public interface IUserCommandManager
{
    void Create(UserEntity user);
    
    void Update(UserEntity user);
    
    void Delete(UserEntity user);
    
    void SaveChanges();
}