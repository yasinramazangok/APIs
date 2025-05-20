using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
