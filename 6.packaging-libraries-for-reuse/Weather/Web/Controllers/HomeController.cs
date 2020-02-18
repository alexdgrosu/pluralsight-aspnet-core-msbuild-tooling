using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Weather(string city = "Aarhus, DK")
        {
            var client = new OpenWeatherMapClient();

            var weather = await client.GetCurrentWeatherByCityAsync(city);

            if (weather is null)
            {
                return Content($"No weather for {city}");
            }

            var message = $"<h2>{city}</h2>"
                + $"<img src=\"{weather.FirstCondition?.IconUrl}\" /><br>"
                + $"Condition: {weather.FirstCondition?.Description}<br>"
                + $"Temp: {weather.Main?.Temperature}<br>"
                + $"Low: {weather.Main?.MinTemperature}<br>"
                + $"High: {weather.Main?.MaxTemperature}<br>"
                + $"Humidity: {weather.Main?.Humidity}%<br>";

            return Content(message, "text/html");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
