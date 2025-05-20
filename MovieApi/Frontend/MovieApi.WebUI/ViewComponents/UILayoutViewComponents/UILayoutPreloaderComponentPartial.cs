using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutPreloaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
