using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;

namespace YummyRestaurant.WebApi.Controllers
{
    // This sets the base route to "api/Chefs"
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        // The database context used to access the database
        private readonly YummyRestaurantApiContext _context;

        // Constructor: the context is injected automatically when the controller is created
        public ChefsController(YummyRestaurantApiContext context)
        {
            _context = context;
        }

        // Get all chefs from the database (GET: api/Chefs)
        [HttpGet]
        public IActionResult GetChefList()
        {
            // Fetch all chef records from the Chefs table
            var chefs = _context.Chefs.ToList();
            return Ok(chefs); // Return 200 OK with the list of chefs
        }

        // Get a single chef by Id (GET: api/Chefs/GetChefById?id=1)
        [HttpGet("GetChefById")]
        public IActionResult GetChefById(int id)
        {
            // Find the chef with the specified Id
            var chef = _context.Chefs.Find(id);
            return Ok(chef); // Return 200 OK with the chef details
        }

        // Add a new chef to the database (POST: api/Chefs)
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            // Add the new chef to the Chefs table
            _context.Chefs.Add(chef);
            _context.SaveChanges(); // Save changes to the database
            return Ok("Şef başarıyla eklendi!"); // Return success message
        }

        // Delete a chef by Id (DELETE: api/Chefs?id=1)
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            // Find the chef by Id
            var chef = _context.Chefs.Find(id);
            // Remove the chef from the database
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Şef başarıyla silindi!");
        }

        // Update an existing chef (PUT: api/Chefs)
        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            // Update the chef details in the database
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef başarıyla güncellendi!");
        }
    }

}
