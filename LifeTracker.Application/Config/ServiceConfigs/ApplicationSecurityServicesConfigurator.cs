using LifeTracker.Application.Services.Security.PasswordService;
using LifeTracker.Application.Services.Security.TokenService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Application.Config.ServiceConfigs;

public static class ApplicationSecurityServicesConfigurator
{
    public static void BindSecurityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPasswordService, PasswordService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
    }
}