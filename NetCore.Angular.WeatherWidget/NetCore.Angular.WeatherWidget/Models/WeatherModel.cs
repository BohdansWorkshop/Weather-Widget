namespace NetCore.Angular.WeatherWidget.Models
{
    public class WeatherModel
    {
        public WeatherDescriptionModel WeatherDescription { get; set; }
        public EnvironmentModel Environment { get; set; }
        public WindModel Wind { get; set; }
    }

    public class WeatherDescriptionModel
    {
        public string Main;
        public string Description;
        public string Icon = "";
    }

    public class EnvironmentModel
    {
        public double Temp;
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
}
