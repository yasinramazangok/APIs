using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Dtos.ContactDtos;
using YummyRestaurant.WebApi.Entities;

namespace YummyRestaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly YummyRestaurantApiContext _context;

        public ContactsController(YummyRestaurantApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContactList()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var contact = _context.Contacts.Find(id);
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Email = createContactDto.Email;
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.MapInformation = createContactDto.MapInformation;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.MapInformation = updateContactDto.MapInformation;
            contact.OpenHours = updateContactDto.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı!");
        }
    }
}
