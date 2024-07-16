using System.Security.Claims;
using dotnet_helpers.Enums;
using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.Expense.Interfaces;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Domain.Extensions;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Infrastructure.DataManagers.Expenses;
using Microsoft.AspNetCore.Http;

namespace LifeTracker.Application.Services.Entities.Expense;

public class ExpenseQueryService(IExpenseQueryManager expenseQueryManager, 
                                 IUserQueryService userQueryService,
                                 IHttpContextAccessor httpContextAccessor) : IExpenseQueryService
{
    public ServiceResult<IReadOnlyCollection<ExpenseDto>> GetExpensesForCurrentUser()
    {
        var loggedInUserEmail = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrWhiteSpace(loggedInUserEmail))
        {
            return ServiceResult<IReadOnlyCollection<ExpenseDto>>.MakeFailure("User not logged in.");
        }

        var loggedInUserResult = userQueryService.GetUserDtoByEmail(loggedInUserEmail);

        if (loggedInUserResult.Result != ResultType.Success)
        {
            return ServiceResult<IReadOnlyCollection<ExpenseDto>>.MakeFailure("Unable to find user.");
        }
        
        var expenses = expenseQueryManager.GetExpenseList(predicate: expense => expense.CreatedByUserId == loggedInUserResult.Data!.Id || expense.ModifiedbyUserId == loggedInUserResult.Data.Id);

        if (expenses.IsNull())
        {
            return ServiceResult<IReadOnlyCollection<ExpenseDto>>.MakeFailure("No expenses for this user.");
        }

        return ServiceResult<IReadOnlyCollection<ExpenseDto>>.MakeSuccess(expenses.Select(expense => new ExpenseDto(expense)).ToList());
    }
}