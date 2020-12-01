using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MyAPI.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("temperatures")]
        public IActionResult AddTemperature([FromBody] Temperature temperature)
        {
            try
            {
                return BadRequest("POST: NYI");
            }
            catch (Exception exc)
            {
                return BadRequest("Add Temperature error. " + exc.Message);
            }
        }

        [HttpPut("temperatures")]
        public IActionResult UpdateTemperature([FromBody] Temperature temperature) // PUT can create, if not exist but:  origin server MUST inform the user agent by sending a 201 (Created) response
        {
            try
            {
                return BadRequest("PUT: NYI");
            }
            catch (Exception exc)
            {
                return BadRequest("Update Temperature error. " + exc.Message);
            }
        }

        [HttpDelete("temperatures")]
        public IActionResult DeleteAllTemperatures()
        {
            try
            {
                return BadRequest("DELETE: NYI");
            }
            catch (Exception exc)
            {
                return BadRequest("Delete All Temperatures error. " + exc.Message);
            }
        }

        [HttpDelete("temperatures/zip/{zip}")]
        public IActionResult DeleteByZip(string zip)
        {
            try
            {
                return BadRequest("DELETE: NYI");
            }
            catch (Exception exc)
            {
                return BadRequest("Delete All Temperatures by Zip error. " + exc.Message);
            }
        }
        [HttpDelete("temperatures/timestamp/{encodedTimestamp}/zip/{zip}")]
        public IActionResult DeleteByTimestampZip(string encodedTimestamp, string zip)
        {
            try
            {
                string timestamp = System.Uri.UnescapeDataString(encodedTimestamp);
                return BadRequest("DELETE: NYI");
            }
            catch (Exception exc)
            {
                return BadRequest("Delete Single Temperature by Timestamp & Zip error. " + exc.Message);
            }
        }
    }
    
    public class Temperature
    {
        public double FahrenheitTemperature { get; set; }
        public string Timestamp { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
