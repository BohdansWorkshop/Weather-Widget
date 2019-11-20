export class WeatherModel {
    weatherDescription: WeatherDescription = new WeatherDescription();
    environment: Environment = new Environment();
    wind: Wind = new Wind();
}

export class WeatherDescription {
    main: string;
    description: string;
    icon: string;
}

export class Environment {
    temp: number;
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
