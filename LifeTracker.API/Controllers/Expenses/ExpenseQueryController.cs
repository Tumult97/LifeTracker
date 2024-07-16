using dotnet_helpers.Extensions;
using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.Expense.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeTracker.API.Controllers.Expenses;

[Route("api/Expenses")]
public class ExpenseQueryController() : BaseController
{
    
    [HttpPost]
    public IActionResult GetExpensesForCurrentUser([FromServices] IExpenseQueryService expenseQueryService)
    {
        var result = expenseQueryService.GetExpensesForCurrentUser();
        return result.ToActionResult();
    }
}