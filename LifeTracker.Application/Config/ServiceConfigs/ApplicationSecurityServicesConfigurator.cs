using LifeTracker.Application.Services.Entities.UserService;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Application.Services.Security.TokenService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Application.Config.ServiceConfigs;

public static class ApplicationSecurityServicesConfigurator
{
    public static void BindSecurityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IPasswordService, PasswordService>();
        builder.Services.AddTransient<ITokenService, TokenService>();
    }
}