using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;

namespace LifeTracker.Application.Services.Entities.UserService.Interfaces;

public interface IUserCommandService
{
    Task<UserDto> RegisterUserAsync(RegisterRequestModel registerRequestModel);
}