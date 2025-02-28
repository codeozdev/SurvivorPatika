namespace SurvivorPatika.Models;

public class Competitors : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Foreign key for Category
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}