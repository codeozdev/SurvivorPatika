using SurvivorPatika.Models;

namespace SurvivorPatika.MockData;

public static class CompetitorService
{
    public static readonly List<Competitors> Competitors =
    [
        new Competitors { Id = 1, CategoryId = 1, FirstName = "Acun", LastName = "Ilıcalı", IsDeleted = false },
        new Competitors { Id = 2, CategoryId = 1, FirstName = "Aleyna", LastName = "Avcı", IsDeleted = false },
        new Competitors { Id = 3, CategoryId = 2, FirstName = "Elif", LastName = "Demirtaş", IsDeleted = false }
    ];
}