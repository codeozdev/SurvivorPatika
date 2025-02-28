using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurvivorPatika.DTO;
using SurvivorPatika.MockData;
using SurvivorPatika.Models;

namespace SurvivorPatika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController() : ControllerBase
    {
        private readonly List<Category> _categories = CategoryService.Categories;
        private readonly List<Competitors> _competitors = CompetitorService.Competitors;


        [HttpGet]
        public IActionResult Get()
        {
            // Kategorilere bağlı yarışmacıları ekle
            var categoriesWithCompetitors = _categories.Select<Category, object>(category => new
            {
                category.Id,
                category.Name,
                category.IsDeleted,
                category.CreatedDate,
                category.ModifiedDate,
                Competitors = _competitors.Where(c => c.CategoryId == category.Id).ToList()
            }).ToList();

            return Ok(categoriesWithCompetitors);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            // Kategoriye bağlı yarışmacıları ekleyelim
            var categoryWithCompetitors = new
            {
                category.Id,
                category.Name,
                category.IsDeleted,
                category.CreatedDate,
                category.ModifiedDate,
                Competitors = _competitors.Where(c => c.CategoryId == category.Id).ToList()
            };

            return Ok(categoryWithCompetitors);
        }


        [HttpPost]
        public IActionResult Post(CategoryRequest category)
        {
            var newCategory = new Category
            {
                Id = _categories.Max(c => c.Id) + 1,
                Name = category.Name,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _categories.Add(newCategory);
            return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, CategoryRequest category)
        {
            var selectedCategory = _categories.FirstOrDefault(x => x.Id == id);
            if (selectedCategory == null)
            {
                return NotFound();
            }

            selectedCategory.Name = category.Name;
            selectedCategory.ModifiedDate = DateTime.Now;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var selectedCategory = _categories.FirstOrDefault(x => x.Id == id);
            if (selectedCategory == null)
            {
                return NotFound();
            }

            _categories.Remove(selectedCategory);
            return NoContent();
        }
    }
}