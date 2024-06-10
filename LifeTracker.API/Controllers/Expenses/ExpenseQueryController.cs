using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.Expense.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeTracker.API.Controllers.Expenses;

[Microsoft.AspNetCore.Components.Route("api/Expenses")]
public class ExpenseQueryController(IExpenseQueryService expenseQueryService) : BaseController
{
    
    [HttpPost]
    public IActionResult GetExpensesForCurrentUser()
    {
        var result = expenseQueryService.GetExpensesForCurrentUser();
        return Ok(result);
    }
}