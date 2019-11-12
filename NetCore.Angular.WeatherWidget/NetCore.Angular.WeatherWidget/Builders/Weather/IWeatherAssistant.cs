using NetCore.Angular.WeatherWidget.Models;
using System.Threading.Tasks;

namespace NetCore.Angular.WeatherWidget.Builders.Weather
{
    public interface IWeatherAssistant
    {
        Task<WeatherModel> GetWeather(double latitude, double longitude);
    }
}
