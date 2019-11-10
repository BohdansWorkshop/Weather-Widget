using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Angular.WeatherWidget.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWeatherByCoordinates(double latitude, double longitude)
        {
            //TODO add coordinates transform from google to absolute format
            using(var client = new HttpClient())
            {
                var url = new Uri("https://fcc-weather-api.glitch.me/api/current?lat=35&lon=139");
                var result = await client.GetAsync(url);
                if(result.IsSuccessStatusCode)
                {
                    return Ok(await result.Content.ReadAsStringAsync());
                }
                else
                {
                    return BadRequest(result);
                }
            }
        }

    }
}