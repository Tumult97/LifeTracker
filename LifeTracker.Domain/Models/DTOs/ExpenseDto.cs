using LifeTracker.Domain.Enums;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Domain.Models.DTOs;

public class ExpenseDto(ExpenseEntity expenseEntity)
{
    public string Name { get; set; } = expenseEntity.Name;
    public decimal Amount { get; set; } = expenseEntity.Amount;
    public DateTime Date { get; set; } = expenseEntity.Date;
    public ExpenseCategory Category { get; set; } = expenseEntity.Category;
    public string Store { get; set; } = expenseEntity.Store;
    public int? CreatedByUserId { get; set; } = expenseEntity.CreatedByUserId;
}