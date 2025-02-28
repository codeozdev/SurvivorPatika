namespace SurvivorPatika.Models;

public abstract class Category : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Competitors> Competitors { get; set; } = new List<Competitors>();
}