using LifeTracker.Domain.Enums;

namespace LifeTracker.Domain.Models.Infrastructure.Entities;

public class ExpenseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public ExpenseCategory Category { get; set; } = 0;
    public string Store { get; set; } = null!;
    
    
    public UserEntity User { get; set; } = null!;
}