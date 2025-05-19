using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
