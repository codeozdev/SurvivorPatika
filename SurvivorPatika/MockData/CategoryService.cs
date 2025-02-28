using SurvivorPatika.Models;

namespace SurvivorPatika.MockData;

public class CategoryService
{
    public static readonly List<Category> Categories =
    [
        new Category()
        {
            Id = 1, Name = "Ünlüler", IsDeleted = false, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now
        },
        new Category()
        {
            Id = 2, Name = "Gönüllüler", IsDeleted = false, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now
        },
    ];
}