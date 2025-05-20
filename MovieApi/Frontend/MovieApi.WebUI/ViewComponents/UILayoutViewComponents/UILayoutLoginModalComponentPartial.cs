using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutLoginModalComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
