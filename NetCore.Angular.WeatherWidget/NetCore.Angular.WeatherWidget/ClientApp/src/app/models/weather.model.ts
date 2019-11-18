export class WeatherModel {
    weatherDescription: WeatherDescription;
    environment: Environment;
    wind: Wind;
    geoData: GeoData;
}

export class WeatherDescription {
    id: number;
    main: string;
    description: string;
    icon: string;
}

export class Environment {
    temp: number;
    temp_min: number;
    temp_max: number;
    pressure: number;
    humidity: number;
    visibility: number;
    clouds: number;
}

export class Wind {
    speed: number;
    deg: number;
    gust: number;
}

export class GeoData {
    country: string;
    city: string;
    sunrise: string;
    sunset: string;
}
