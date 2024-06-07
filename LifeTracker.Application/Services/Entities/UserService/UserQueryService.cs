using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Application.Services.Security.TokenService;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Infrastructure.Command_Managers.User;

namespace LifeTracker.Application.Services.Entities.UserService;

public class UserQueryService(IPasswordService passwordService, IUserQueryManager userQueryManager, ITokenService tokenService) : IUserQueryService
{
    public async Task<ServiceResult<string?>> Login(LoginRequestModel loginRequestModel)
    {
        var user = await userQueryManager.GetByEmailAddressAsync(loginRequestModel.Email);

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