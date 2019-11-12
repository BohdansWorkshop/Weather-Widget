using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            var weather = await GetWeather(latitude, longitude);

            if(weather != null)
            {
                return Ok(weather);
            }
            else
            {
                return BadRequest("Something went wrong, check log if it's available.");
            }
            

        }



        private async Task<WeatherModel> GetWeather(double latitude, double longitude)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://fcc-weather-api.glitch.me/api/current?lat=35&lon=139");
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();



          

                    var jsonContent = JsonConvert.DeserializeObject<JObject>(content);
                    var wetha = JsonToWeatherModel(jsonContent);

                    return wetha;
                }
            }
            return new WeatherModel();
        }


        private WeatherModel JsonToWeatherModel(JObject json)
        {
            var weatherModel = new WeatherModel();

            //var weatherDescription = new WeatherDescription();

            //var jsonWeatherDesc = json["weather"];
            //weatherDescription.Id = int.Parse(jsonWeatherDesc.First["id"].ToString());
            //weatherDescription.Main = jsonWeatherDesc.First["main"].ToString();
            //weatherDescription.Description = jsonWeatherDesc.First["description"].ToString();
            //weatherDescription.Icon = jsonWeatherDesc.First["icon"].ToString();

            var weatherDescription = JsonConvert.DeserializeObject<WeatherDescription>(json["weather"].First.ToString());

            weatherModel.WeatherDescription = weatherDescription;


            var jsonEnvironment = json["main"];
            //var environment = new Environment();
            var environment = JsonConvert.DeserializeObject<Environment>(json["main"].ToString());

            //environment.Humidity = int.Parse(jsonEnvironment.First["humidity"].ToString());
            //environment.Pressure = int.Parse(jsonEnvironment.First["pressure"].ToString());
            //environment.Temperature = int.Parse(jsonEnvironment.First["temp"].ToString());
            //environment.TemperatureMin = int.Parse(jsonEnvironment.First["temp_min"].ToString());
            //environment.TemperatureMax = int.Parse(jsonEnvironment.First["temp_max"].ToString());

            environment.Clouds = int.Parse(json["clouds"].First["all"].ToString());
            environment.Visibility = int.Parse(json["visibility"].ToString());

            weatherModel.Environment = environment;



            var windModel = new WindModel();

            var jsonWind = json["wind"];
            windModel.Speed = int.Parse(jsonWind.First["speed"].ToString());
            windModel.Deg = int.Parse(jsonWind.First["deg"].ToString());

            weatherModel.Wind = windModel;


            var geoData = new GeoData();
            geoData.Id = int.Parse(json["id"].ToString());
            geoData.Country = json["sys"].First["country"].ToString();
            geoData.City = json["name"].ToString();

            // parse to datetime
            geoData.Sunrise = json["sys"].First["sunrise"].ToString();
            geoData.Sunset = json["sys"].First["sunset"].ToString();

            geoData.Type = int.Parse(json["sys"].First["type"].ToString());
            geoData.TimeZone = json["timezone"].ToString();

            weatherModel.GeoData = geoData;

            return weatherModel;
        }

    }
}