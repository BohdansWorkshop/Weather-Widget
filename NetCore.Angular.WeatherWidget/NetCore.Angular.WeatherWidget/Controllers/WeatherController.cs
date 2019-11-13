using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Angular.WeatherWidget.Builders.Weather;
using NetCore.Angular.WeatherWidget.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetCore.Angular.WeatherWidget.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherAssistant _weatherAsistant;
        public WeatherController(IWeatherAssistant weatherAssistant)
        {
            _weatherAsistant = weatherAssistant;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherByCoordinates(double latitude, double longitude)
        {
            try
            {
                var weather = await _weatherAsistant.GetWeather(latitude, longitude);
                return Ok(weather);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}