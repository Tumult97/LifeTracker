using LifeTracker.Application.Services.Entities.UserService;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.QueryManagers.Users;

public class UserQueryManager(DatabaseContext context) : IUserQueryManager
{
    public async Task<UserEntity?> GetByEmailAddressAsync(string emailAddress)
    {
        return await context.users.FirstOrDefaultAsync(user => user.Email == emailAddress);
    }
}