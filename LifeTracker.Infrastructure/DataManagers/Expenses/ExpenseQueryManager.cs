using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.DataManagers.Expenses;

public class ExpenseQueryManager(DatabaseContext context) : IExpenseQueryManager
{
    public async Task<List<ExpenseEntity>> GetExpenseListAsync(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUser = false)
    {
        var expenseContext = (includeTracking ? context.Expenses : context.Expenses.AsNoTracking()).IgnoreAutoIncludes();
        
        expenseContext = includeUser ? expenseContext.Include(x => x.User) : expenseContext;
        
        if (predicate != null)
        {
            return await expenseContext.Where(predicate).ToListAsync();
        }
        
        return await expenseContext.ToListAsync();
    }

    public async Task<ExpenseEntity?> GetExpenseSingleAsync(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUser = false)
    {
        var expenseContext = (includeTracking ? context.Expenses : context.Expenses.AsNoTracking()).IgnoreAutoIncludes();
        
        expenseContext = includeUser ? expenseContext.Include(x => x.User) : expenseContext;
        
        if (predicate != null)
        {
            return await expenseContext.FirstOrDefaultAsync(predicate);
        }
        
        return await expenseContext.FirstOrDefaultAsync();
    }
}