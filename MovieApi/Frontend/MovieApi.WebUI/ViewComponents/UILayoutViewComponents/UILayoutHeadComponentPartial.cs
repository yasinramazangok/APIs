using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
