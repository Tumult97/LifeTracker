using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Application.Services.Security.TokenService;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Infrastructure.DataManagers.Users;

namespace LifeTracker.Application.Services.Entities.UserService;

public class UserQueryService(IPasswordService passwordService, IUserQueryManager userQueryManager, ITokenService tokenService) : IUserQueryService
{
    public async Task<ServiceResult<string?>> Login(LoginRequestModel loginRequestModel)
    {
        var user = await userQueryManager.GetUserSingleAsync(predicate: user => user.Email.ToLower() == loginRequestModel.EmailOrUsername.ToLower() || user.Username == loginRequestModel.EmailOrUsername);

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
}