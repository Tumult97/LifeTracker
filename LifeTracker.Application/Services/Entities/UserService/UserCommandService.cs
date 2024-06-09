using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.DataManagers.Users;
using Microsoft.Extensions.Configuration;

namespace LifeTracker.Application.Services.Entities.UserService;

public class UserCommandService(IPasswordService passwordService, IUserCommandManager userCommandManager) : IUserCommandService
{
    
    public async Task<UserDto> RegisterUserAsync(RegisterRequestModel registerRequestModel)
    {
        string passwordSalt = passwordService.GenerateSalt();
        string passwordHash = passwordService.ComputeHash(registerRequestModel.Password, passwordSalt, 3);

        var user = new UserEntity(
            firstName: registerRequestModel.FirstName,
            lastName: registerRequestModel.LastName,
            email: registerRequestModel.Email,
            username: registerRequestModel.Username,
            passwordHash: passwordHash,
            passwordSalt: passwordSalt);
        
        userCommandManager.Create(user);
        userCommandManager.SaveChanges();

        return new UserDto(user);
    }
}