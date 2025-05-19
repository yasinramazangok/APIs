using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
