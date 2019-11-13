export class WeatherModel {
    WeatherDescription: WeatherDescription;
    Environment: Environment;
    Wind: Wind;
    GeoData: GeoData;
}

export class WeatherDescription {
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
    Clouds: number;
}

export class Wind {
    Speed: number;
    Deg: number;
    Gust: number;
}

export class GeoData {
    Country: string;
    City: string;
    Sunrise: string;
    Sunset: string;
}
