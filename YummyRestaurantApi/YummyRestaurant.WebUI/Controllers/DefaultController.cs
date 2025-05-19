using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
