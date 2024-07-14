using LifeTracker.Domain.Enums;

namespace LifeTracker.Domain.Models.Infrastructure.Entities;

public class ExpenseEntity : AuditModelBase
{
    public string Name { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public ExpenseCategory Category { get; set; } = 0;
    public string Store { get; set; } = null!;
}