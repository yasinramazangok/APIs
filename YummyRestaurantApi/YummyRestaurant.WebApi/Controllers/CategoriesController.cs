using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;

namespace YummyRestaurant.WebApi.Controllers
{
    // This sets the base route to "api/Categories"
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // The database context used to interact with the database
        private readonly YummyRestaurantApiContext _context;

        // Constructor: runs when the controller is created
        // The context is injected automatically (Dependency Injection)
        public CategoriesController(YummyRestaurantApiContext context)
        {
            _context = context;
        }

        // Get all categories (GET: api/Categories)
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            // Get all category records from the database
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        // Get a single category by its Id (GET: api/Categories/GetCategoryById?id=1)
        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            // Find the category with the given Id
            var category = _context.Categories.Find(id);
            return Ok(category);
        }

        // Create a new category (POST: api/Categories)
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            // Add the new category to the database
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla eklendi!");
        }

        // Delete a category by Id (DELETE: api/Categories?id=1)
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            // Find the category with the given Id
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category); // Remove it from the database
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi!");
        }

        // Update an existing category (PUT: api/Categories)
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            // Update the existing category in the database
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi!");
        }
    }
}
