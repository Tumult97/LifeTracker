using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Expenses;

public interface IExpenseQueryManager
{
    Task<List<ExpenseEntity>> GetExpenseListAsync(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUser = false);
    Task<ExpenseEntity?> GetExpenseSingleAsync(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUser = false);
}