using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Dtos.MessageDtos;
using YummyRestaurant.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyRestaurantApiContext _context;

        public MessagesController(IMapper mapper, YummyRestaurantApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMessageList()
        {
            var messages = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(messages));
        }

        [HttpGet("GetMessageById")]
        public IActionResult GetMessageById(int id)
        {
            var message = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(message));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok("Mesaj ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok("Mesaj silme işlemi başarılı!");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj güncelleme işlemi başarılı!");
        }
    }
}
