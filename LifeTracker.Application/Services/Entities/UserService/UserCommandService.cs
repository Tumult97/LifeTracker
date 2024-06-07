using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Command_Managers.User;
using Microsoft.Extensions.Configuration;

namespace LifeTracker.Application.Services.Entities.UserService;

public class UserCommandService(IPasswordService passwordService, IConfiguration configuration, IUserCommandManager userCommandManager) : IUserCommandService
{
    private readonly string _pepper = configuration["PasswordPepper"]!;
    
    public async Task<UserDtoModel> RegisterUserAsync(RegisterRequestModel registerRequestModel)
    {
        string passwordSalt = passwordService.GenerateSalt();
        string passwordHash = passwordService.ComputeHash(registerRequestModel.Password, passwordSalt, _pepper, 3);

        var user = new UserEntity(
            firstName: registerRequestModel.FirstName,
            lastName: registerRequestModel.LastName,
            email: registerRequestModel.Email,
            username: registerRequestModel.Username,
            passwordHash: passwordHash,
            passwordSalt: passwordSalt);
        
        userCommandManager.CreateAsync(user);
        userCommandManager.SaveChanges();

        return new UserDtoModel(user);
    }
}