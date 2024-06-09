namespace LifeTracker.Domain.Models.API;

public class GroupCreationRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public List<int>? UserIds { get; set; }
}