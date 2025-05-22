using Microsoft.AspNetCore.Mvc;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
