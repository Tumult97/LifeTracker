using LifeTracker.Infrastructure.QueryManagers.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Infrastructure.Config;

public static class QueryManagerConfigurator
{
    public static WebApplicationBuilder ConfigureQueryManagers(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserQueryManager, UserQueryManager>();

        return builder;
    }
}