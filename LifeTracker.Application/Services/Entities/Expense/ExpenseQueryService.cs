using LifeTracker.Application.Services.Entities.Expense.Interfaces;
using LifeTracker.Infrastructure.DataManagers.Expenses;

namespace LifeTracker.Application.Services.Entities.Expense;

public class ExpenseQueryService(IExpenseQueryManager expenseQueryManager) : IExpenseQueryService
{
    public IReadOnlyCollection<object> GetExpensesForCurrentUser()
    {
        throw new NotImplementedException();
    }
}