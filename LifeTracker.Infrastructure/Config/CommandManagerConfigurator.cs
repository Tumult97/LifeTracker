using LifeTracker.Infrastructure.DataManagers.Expenses;
using LifeTracker.Infrastructure.DataManagers.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Infrastructure.Config;

public static class CommandManagerConfigurator
{
    public static WebApplicationBuilder ConfigureCommandManagers(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IExpenseCommandManager, ExpenseCommandManager>();
        builder.Services.AddTransient<IUserCommandManager, UserCommandManager>();

        return builder;
    }
}