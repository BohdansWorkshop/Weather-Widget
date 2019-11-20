using System;
using System.Net.Http;
using System.Threading.Tasks;
using NetCore.Angular.WeatherWidget.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetCore.Angular.WeatherWidget.Builders.Weather
{
    public class WeatherAssistant : IWeatherAssistant
    {
        private readonly string _weatherApiUrl;
        public WeatherAssistant(string weatherApiUrl)
        {
            _weatherApiUrl = weatherApiUrl;
        }

       public async Task<WeatherModel> GetWeather(double latitude, double longitude)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_weatherApiUrl}?lat={latitude}&lon={longitude}";
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


        internal WeatherModel JsonToWeatherModel(JObject json)
        {
            var weatherModel = new WeatherModel();
            var weatherDescription = JsonConvert.DeserializeObject<WeatherDescriptionModel>(json["weather"].First.ToString());
            weatherModel.WeatherDescription = weatherDescription;

            var environment = JsonConvert.DeserializeObject<EnvironmentModel>(json["main"].ToString());
            environment.Clouds = int.Parse(json["clouds"]["all"].ToString());
            environment.Visibility = int.Parse(json["visibility"].ToString());
            weatherModel.Environment = environment;

            var windModel = JsonConvert.DeserializeObject<WindModel>(json["wind"].ToString());
            weatherModel.Wind = windModel;

            return weatherModel;
        }
    }
}
