using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly YummyRestaurantApiContext _context;
        // Constructor to inject the database context
        public TestimonialsController(YummyRestaurantApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTestimonialList()
        {
            var testimonials = _context.Testimonials.ToList();
            return Ok(testimonials);
        }

        [HttpGet("GetTestimonialById")]
        public IActionResult GetTestimonialById(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            return Ok(testimonial);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Referans başarıyla eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return Ok("Referans başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Referans başarıyla güncellendi!");
        }
    }
}
