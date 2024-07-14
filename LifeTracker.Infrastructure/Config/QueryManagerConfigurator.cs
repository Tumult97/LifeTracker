using LifeTracker.Infrastructure.DataManagers.Expenses;
using LifeTracker.Infrastructure.DataManagers.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Infrastructure.Config;

public static class QueryManagerConfigurator
{
    public static WebApplicationBuilder ConfigureQueryManagers(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IExpenseQueryManager, ExpenseQueryManager>();
        builder.Services.AddTransient<IUserQueryManager, UserQueryManager>();

        return builder;
    }
}