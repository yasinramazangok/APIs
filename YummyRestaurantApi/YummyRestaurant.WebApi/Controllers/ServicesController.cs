using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly YummyRestaurantApiContext _context;
        // Constructor to inject the database context
        public ServicesController(YummyRestaurantApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetServiceList()
        {
            var services = _context.Services.ToList();
            return Ok(services);
        }

        [HttpGet("GetServiceById")]
        public IActionResult GetServiceById(int id)
        {
            var service = _context.Services.Find(id);
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Hizmet başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return Ok("Hizmet başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Hizmet başarıyla güncellendi!");
        }
    }
}
