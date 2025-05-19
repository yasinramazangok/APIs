using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
