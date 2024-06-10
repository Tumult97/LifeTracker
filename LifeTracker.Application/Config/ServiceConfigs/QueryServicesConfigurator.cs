using LifeTracker.Application.Services.Entities.GroupService;
using LifeTracker.Application.Services.Entities.GroupService.Interfaces;
using LifeTracker.Application.Services.Entities.UserService;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Application.Config.ServiceConfigs;

public static class QueryServicesConfigurator
{
    public static void BindQueryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IGroupQueryService, GroupQueryService>();
        builder.Services.AddTransient<IUserQueryService, UserQueryService>();
    }
}