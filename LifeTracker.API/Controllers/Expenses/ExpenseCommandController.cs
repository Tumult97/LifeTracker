using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.Expense.Interfaces;
using LifeTracker.Infrastructure.DataManagers.Expenses;
using Microsoft.AspNetCore.Components;

namespace LifeTracker.API.Controllers.Expenses;

[Route("api/Expenses")]
public class ExpenseCommandController(IExpenseCommandService expenseCommandService): BaseController
{
    
}