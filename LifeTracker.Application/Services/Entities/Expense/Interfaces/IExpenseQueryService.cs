using dotnet_helpers.Models;
using LifeTracker.Domain.Models.DTOs;

namespace LifeTracker.Application.Services.Entities.Expense.Interfaces;

public interface IExpenseQueryService
{
    ServiceResult<IReadOnlyCollection<ExpenseDto>> GetExpensesForCurrentUser();
}