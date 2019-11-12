export class WeatherModel {
    WeatherDescription: Weather;
    Environment: Environment;
    Wind: Wind;
    Clouds: Clouds;
    GeoData: GeoData;
}

export class Weather {
    Id: number;
    Main: string;
    Description: string;
    Icon: string;
}

export class Environment {
    Temperature: number;
    TemperatureMin: number;
    TemperatureMax: number;
    Pressure: number;
    Humidity: number;
    Visibility: number;
}

export class Wind {
    Speed: number;
    Deg: number;
    Gust: number;
}

export class Clouds {
    All: number;
}

export class GeoData {
    Country: string;
    City: string;
    Sunrise: string;
    Sunset: string;
}
