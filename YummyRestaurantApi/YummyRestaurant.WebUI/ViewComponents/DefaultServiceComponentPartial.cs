﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyRestaurant.WebUI.Dtos.ServiceDtos;

namespace YummyRestaurant.WebUI.ViewComponents
{
    public class DefaultServiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7169/api/Services/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(services);
            }
            return View();
        }
    }
}
