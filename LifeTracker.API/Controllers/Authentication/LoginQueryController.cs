using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LifeTracker.API.Controllers.Base;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LifeTracker.API.Controllers.Authentication;

public class LoginQueryController(IConfiguration config) : AuthController
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login([FromQuery] LoginRequestModel loginRequestModel)
    {
        IActionResult response = Unauthorized();

        var user = AuthenticateUser(loginRequestModel);

        if (user != null)
        {
            var tokenString = GenerateJwtWebToken(user);
            response = Ok(new { token = tokenString });
        }

        return response;
    }

    private UserDtoModel? AuthenticateUser(LoginRequestModel loginRequestModel)
    {
        UserDtoModel? user = null;

        if (loginRequestModel.Username == "test" || loginRequestModel.Email == "test")
        {
            user = new UserDtoModel(loginRequestModel);
        }

        return user;
    }
    
    private string GenerateJwtWebToken(UserDtoModel userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var token = new JwtSecurityToken(
            issuer:             config["Jwt:Issuer"],
            audience:           config["Jwt:Issuer"],
            claims:             claims,
            expires:            DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}