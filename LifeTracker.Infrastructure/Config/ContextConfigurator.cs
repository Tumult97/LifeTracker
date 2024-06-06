using LifeTracker.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Infrastructure.Config;

public static class ContextConfigurator
{
    public static WebApplicationBuilder ConfigureContexts(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        
        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
           options
               .UseSqlServer(
                connectionString, 
                o => 
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                     .MigrationsHistoryTable(
                         tableName: HistoryRepository.DefaultTableName)
            );
        });

        return builder;
    }
}