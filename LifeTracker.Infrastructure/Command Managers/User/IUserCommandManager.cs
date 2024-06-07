using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.Command_Managers.User;

public interface IUserCommandManager
{
    void CreateAsync(UserEntity user);
    
    void SaveChanges();
}