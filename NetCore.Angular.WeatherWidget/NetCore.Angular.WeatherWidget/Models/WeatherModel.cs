namespace NetCore.Angular.WeatherWidget.Models
{
    public class WeatherModel
    {
        public WeatherDescriptionModel WeatherDescription { get; set; }
        public EnvironmentModel Environment { get; set; }
        public WindModel Wind { get; set; }
        public GeoDataModel GeoData { get; set; }
    }

    public class WeatherDescriptionModel
    {
        public int Id;
        public string Main;
        public string Description;
        public string Icon;
    }

    public class EnvironmentModel
    {
        public double Temp;
        public double Temp_Min;
        public double Temp_Max;
        public int Pressure;
        public int Humidity;
        public int Visibility;
        public int Clouds;
    }

    public class WindModel
    {
        public double Speed;
        public double Deg;
        public double Gust;
    }

    public class CloudsModel
    {
        public int All;
    }

    public class GeoDataModel
    {
        public string Country = "";
        public string City = "";
        public string Sunrise = "";
        public string Sunset = "";
    }

}
