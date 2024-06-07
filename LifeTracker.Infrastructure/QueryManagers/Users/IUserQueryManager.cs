using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Application.Services.Entities.UserService;

public interface IUserQueryManager
{
    Task<UserEntity?> GetByEmailAddressAsync(string emailAddress);
}