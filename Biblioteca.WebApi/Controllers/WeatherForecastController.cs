using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Biblioteca.Services;

namespace Biblioteca.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStringServices _stringServices;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringServices stringServices)
        {
            _logger = logger;
            _stringServices = stringServices;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> WeatherForecast()
        {
            return Ok(_stringServices.GetString("Prueba"));
        }

        [HttpPost]
        [Route("All")]
        public async Task<IActionResult> WeatherForecast(WeatherForecast weatherForecast)
        {
            return Ok(0);
        }
    }
}
