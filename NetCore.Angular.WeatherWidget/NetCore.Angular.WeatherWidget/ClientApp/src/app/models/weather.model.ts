export class WeatherModel {
    Weather: Weather;
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
}

export class Clouds {
    All: number;
}

export class GeoData {
    Type: number;
    Id: number;
    Country: string;
    City: string;
    TimeZone: string;
    Sunrise: string;
    Sunset: string;
}
