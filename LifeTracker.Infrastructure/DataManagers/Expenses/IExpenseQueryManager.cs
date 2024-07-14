using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Expenses;

public interface IExpenseQueryManager
{
    List<ExpenseEntity> GetExpenseList(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false);
    ExpenseEntity? GetExpenseSingle(Expression<Func<ExpenseEntity, bool>>? predicate = null, bool includeTracking = false);
}