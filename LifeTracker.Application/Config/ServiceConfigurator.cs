using LifeTracker.Application.Config.ServiceConfigs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Application.Config;

public static class ServiceConfigurator
{
    public static WebApplicationBuilder ConfigureApplicationServices(this WebApplicationBuilder builder)
    {
        builder.BindSecurityServices();
        
        return builder;
    }
}