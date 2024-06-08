using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LifeTracker.Application.Services.Security.TokenService;

public class TokenService(IConfiguration configuration) : ITokenService
{
    /// <summary>
    /// Generates a JSON Web Token (JWT) for the given user information.
    /// </summary>
    /// <param name="userInfo">The user information for which the JWT is generated.</param>
    /// <returns>A string representing the generated JWT.</returns>
    public string GenerateJwtWebToken(UserEntity userInfo)
    {
        // Create a symmetric security key using the secret key from configuration
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
    
        // Create signing credentials using the security key and HMAC-SHA256 algorithm
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define the claims to be included in the JWT
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
    
        // Create the JWT token with specified issuer, audience, claims, expiration time, and signing credentials
        var token = new JwtSecurityToken(
            issuer:             configuration["Jwt:Issuer"],
            audience:           configuration["Jwt:Issuer"],
            claims:             claims,
            expires:            DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        // Return the serialized JWT as a string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}