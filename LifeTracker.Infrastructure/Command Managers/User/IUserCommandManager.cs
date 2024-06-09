using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.Command_Managers.User;

public interface IUserCommandManager
{
    void Create(UserEntity user);
    
    void SaveChanges();
}