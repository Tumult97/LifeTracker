using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Expenses;

public interface IExpenseCommandManager
{
    void CreateExpense(ExpenseEntity expense);
    
    void UpdateExpense(ExpenseEntity expense);
    
    void DeleteExpense(ExpenseEntity expense);
    
    void SaveChanges();
}