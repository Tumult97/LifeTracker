using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Application.Services.Security.TokenService;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Infrastructure.DataManagers.Users;
using Microsoft.AspNetCore.Mvc;

namespace LifeTracker.Application.Services.Entities.UserService;

public class UserQueryService(IPasswordService passwordService, IUserQueryManager userQueryManager, ITokenService tokenService) : IUserQueryService
{
    public ServiceResult<string?> Login(LoginRequestModel loginRequestModel)
    {
        var user = userQueryManager.GetUserSingle(predicate: user => user.Email.ToLower() == loginRequestModel.EmailOrUsername.ToLower() || user.Username == loginRequestModel.EmailOrUsername);

        if (user == null)
        {
            return ServiceResult<string?>.MakeFailure("User not found!");
        }
        
        bool passwordIsValid = passwordService.VerifyPassword(loginRequestModel.Password, user.PasswordHash, user.PasswordSalt);

        if (!passwordIsValid)
        {
            return ServiceResult<string?>.MakeFailure("Incorrect password and email combination provided.");
        }

        string token = tokenService.GenerateJwtWebToken(user);

        return ServiceResult<string?>.MakeSuccess("Login Successful", token);
    }

    public ServiceResult<UserDto> GetUserDtoByEmail(string email)
    {
        var user = userQueryManager.GetUserSingle(predicate: user => user.Email == email);

        if (user == null)
        {
            return ServiceResult<UserDto>.MakeFailure("Cannot Find User.");
        }

        return ServiceResult<UserDto>.MakeSuccess(new UserDto(user));
    }
}