using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Domain.Models.Infrastructure;

public class AuditModelBase
{
    public int Id { get; init; }
    
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public int? CreatedByUserId { get; set; }
    public DateTime DateModified { get; set; } = DateTime.UtcNow;
    public int? ModifiedbyUserId  { get; set; }
}