using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.DataManagers.Expenses;

public class ExpenseQueryManager(DatabaseContext context) : IExpenseQueryManager
{
    public List<ExpenseEntity> GetExpenseList(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false)
    {
        var expenseContext = (includeTracking ? context.Expenses : context.Expenses.AsNoTracking()).IgnoreAutoIncludes();
        
        if (predicate != null)
        {
            return expenseContext.Where(predicate).ToList();
        }
        
        return expenseContext.ToList();
    }

    public ExpenseEntity? GetExpenseSingle(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false)
    {
        var expenseContext = (includeTracking ? context.Expenses : context.Expenses.AsNoTracking()).IgnoreAutoIncludes();
        
        if (predicate != null)
        {
            return expenseContext.FirstOrDefault(predicate);
        }
        
        return expenseContext.FirstOrDefault();
    }
}