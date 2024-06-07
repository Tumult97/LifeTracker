using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Infrastructure.Command_Managers.User;

namespace LifeTracker.Application.Services.Entities.UserService;

public class UserQueryService(IPasswordService passwordService, IUserQueryManager userQueryManager) : IUserQueryService
{
    public async Task<ServiceResult<UserDtoModel>> Login(LoginRequestModel loginRequestModel)
    {
        var user = await userQueryManager.GetByEmailAddressAsync(loginRequestModel.Email);

        if (user == null)
        {
            return ServiceResult<UserDtoModel>.MakeFailure("User not found!");
        }
        
        bool passwordIsValid = passwordService.VerifyPassword(loginRequestModel.Password, user.PasswordHash, user.PasswordSalt);

        if (!passwordIsValid)
        {
            return ServiceResult<UserDtoModel>.MakeFailure("Incorrect password and email combination provided.");
        }

        return ServiceResult<UserDtoModel>.MakeSuccess(new UserDtoModel(user));
    }
}