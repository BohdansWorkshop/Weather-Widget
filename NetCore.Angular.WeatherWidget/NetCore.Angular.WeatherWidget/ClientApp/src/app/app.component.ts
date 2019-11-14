import { Component } from '@angular/core';
import { WeatherService } from './services/weather.service';
import { WeatherModel } from './models/weather.model';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [WeatherService]
})
export class AppComponent {
    title = 'Weather Widget';
    latitude = 0;
    longitude = 0;
    weather: WeatherModel = new WeatherModel();

    constructor(private _weatherService: WeatherService) {}

     GetWeatherByClick(coordinates) {
        var latitude = coordinates.lat;
         var longitude = coordinates.lng;
         this._weatherService.GetWeatherByCoordinates(latitude, longitude).then((response: WeatherModel) => {
             this.weather = response;
         });
    }
}
