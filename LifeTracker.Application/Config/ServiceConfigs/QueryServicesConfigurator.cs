using LifeTracker.Application.Services.Entities.Expense;
using LifeTracker.Application.Services.Entities.Expense.Interfaces;
using LifeTracker.Application.Services.Entities.UserService;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Application.Config.ServiceConfigs;

public static class QueryServicesConfigurator
{
    public static void BindQueryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IExpenseQueryService, ExpenseQueryService>();
        builder.Services.AddTransient<IUserQueryService, UserQueryService>();
    }
}