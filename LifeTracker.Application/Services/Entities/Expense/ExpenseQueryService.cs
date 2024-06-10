using LifeTracker.Application.Services.Entities.Expense.Interfaces;

namespace LifeTracker.Application.Services.Entities.Expense;

public class ExpenseQueryService(IExpenseQueryService expenseQueryService) : IExpenseQueryService
{
    public IReadOnlyCollection<object> GetExpensesForCurrentUser()
    {
        throw new NotImplementedException();
    }
}