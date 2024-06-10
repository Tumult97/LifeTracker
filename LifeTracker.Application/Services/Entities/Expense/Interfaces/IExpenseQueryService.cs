namespace LifeTracker.Application.Services.Entities.Expense.Interfaces;

public interface IExpenseQueryService
{
    IReadOnlyCollection<object> GetExpensesForCurrentUser();
}