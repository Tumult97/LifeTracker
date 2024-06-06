using LifeTracker.Application.Services.Entities.UserService;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.QueryManagers.Users;

public class UserQueryManager : EntityQueryManagerBase<UserEntity>, IUserQueryManager
{
    
}