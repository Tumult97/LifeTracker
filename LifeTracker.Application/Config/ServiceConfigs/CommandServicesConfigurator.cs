using LifeTracker.Application.Services.Entities.UserService;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Application.Config.ServiceConfigs;

public static class CommandServicesConfigurator
{
    public static void BindCommandServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserCommandService, UserCommandService>();
    }
}