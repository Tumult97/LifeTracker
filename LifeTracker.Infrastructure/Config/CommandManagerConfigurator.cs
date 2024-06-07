using LifeTracker.Infrastructure.Command_Managers.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Infrastructure.Config;

public static class CommandManagerConfigurator
{
    public static WebApplicationBuilder ConfigureCommandManagers(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserCommandManager, UserCommandManager>();

        return builder;
    }
}