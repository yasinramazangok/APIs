using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Dtos.FeatureDtos;
using YummyRestaurant.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyRestaurantApiContext _context;

        public FeaturesController(IMapper mapper, YummyRestaurantApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var features = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(features));
        }

        [HttpGet("GetFeatureById")]
        public IActionResult GetFeatureById(int id)
        {
            var feature = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(feature));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _context.Features.Find(id);
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı!");
        }
    }
}
