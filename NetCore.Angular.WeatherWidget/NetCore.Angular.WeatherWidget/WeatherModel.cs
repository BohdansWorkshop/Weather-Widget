namespace NetCore.Angular.WeatherWidget
{
    public class WeatherModel
    {
        public WeatherDescription WeatherDescription { get; set; }
        public Environment Environment { get; set; }
        public WindModel Wind { get; set; }
        public GeoData GeoData { get; set; }
    }

    public class WeatherDescription
    {
        public int Id;
        public string Main;
        public string Description;
        public string Icon;
    }

    public class Environment
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
       public int Speed;
       public int Deg;
    }

    public class Clouds
    {
        public int All;
    }

    public class GeoData
    {
        public int Id;
        public int Type;
        public string Country;
        public string City;
        public string TimeZone;
        public string Sunrise;
        public string Sunset;
    }

}
