using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Trace1.Controllers
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
        private readonly HttpClient _client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var a = Activity.Current; 
            var httpResponseMessage = _client.GetStringAsync("http://localhost:5002/WeatherForecast").Result;

            //var b = Activity.Current;

            //var httpResponseMessage1 = _client.GetStringAsync("http://localhost:5002/WeatherForecast").Result;

            //var c = Activity.Current; 

            return Ok(httpResponseMessage); 
            
        }
    }
}
