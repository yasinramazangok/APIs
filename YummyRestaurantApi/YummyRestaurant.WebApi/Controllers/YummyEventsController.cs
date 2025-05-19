using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly YummyRestaurantApiContext _context;

        public YummyEventsController(YummyRestaurantApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetYummyEventList()
        {
            var yummyEvents = _context.YummyEvents.ToList();
            return Ok(yummyEvents);
        }

        [HttpGet("GetYummyEventById")]
        public IActionResult GetYummyEventById(int id)
        {
            var yummyEvent = _context.YummyEvents.Find(id);
            return Ok(yummyEvent);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Add(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var yummyEvent = _context.YummyEvents.Find(id);
            _context.YummyEvents.Remove(yummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik silme işlemi başarılı!");
        }



        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent YummyEvent)
        {
            _context.YummyEvents.Update(YummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik güncelleme işlemi başarılı!");
        }
    }
}
