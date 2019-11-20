import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { WeatherModel } from '../models/weather.model';

@Injectable()

export class WeatherService {
    readonly rootUrl: string;
    readonly weatherController: string;

    constructor(private HttpClient: HttpClient, @Inject("BASE_URL") baseUrl: string) {
        this.rootUrl = baseUrl + 'api/Weather/';
    }

    GetWeatherByCoordinates(latitude, longitude) {
        return this.HttpClient.get<WeatherModel>(this.rootUrl + "GetWeatherByCoordinates?latitude=" + latitude + "&longitude=" + longitude);
    }
}
