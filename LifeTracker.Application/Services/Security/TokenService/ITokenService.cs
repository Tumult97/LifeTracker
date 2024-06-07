using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Application.Services.Security.TokenService;

public interface ITokenService
{
    string GenerateJwtWebToken(UserEntity userInfo);
}