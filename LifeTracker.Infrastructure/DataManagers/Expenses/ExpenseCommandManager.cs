using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;

namespace LifeTracker.Infrastructure.DataManagers.Expenses;

public class ExpenseCommandManager(DatabaseContext context) : IExpenseCommandManager
{
    public void CreateExpense(ExpenseEntity expense)
    {
        context.Expenses.Add(expense);
    }

    public void UpdateExpense(ExpenseEntity expense)
    {
        context.Expenses.Update(expense);
    }

    public void DeleteExpense(ExpenseEntity expense)
    {
        context.Expenses.Remove(expense);
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}