using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.WebApi.Dtos.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly YummyRestaurantApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, YummyRestaurantApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("GetProductListWithCategory")]
        public IActionResult GetProductListWithCategory()
        {
            var products = _context.Products.Include(x => x.Category).ToList(); 
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(products));
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün ekleme işlemi başarılı!");
            }
            //return Ok(new { message = "Ürün ekleme işlemi başarılı!", data = product });
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün silme işlemi başarılı!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün güncelleme işlemi başarılı!");
            }
        }
    }
}
