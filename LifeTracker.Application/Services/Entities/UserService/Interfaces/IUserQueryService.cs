using dotnet_helpers.Models;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;

namespace LifeTracker.Application.Services.Entities.UserService.Interfaces;

public interface IUserQueryService
{
    ServiceResult<string?> Login(LoginRequestModel loginRequestModel);
    ServiceResult<UserDto> GetUserDtoByEmail(string email);
}