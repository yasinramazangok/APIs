using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultServiceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
