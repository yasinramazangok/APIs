using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.WebUI.Dtos.CategoryDtos;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultMenuCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultMenuCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7169/api/Categories/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(categories);
            }
            return View();
        }
    }
}
