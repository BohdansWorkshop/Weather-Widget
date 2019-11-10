import { Component } from '@angular/core';
import { WeatherService } from './services/weather.service';

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

    constructor(private _weatherService: WeatherService) {

    }

    async GetWeatherByClick(coordinates) {
        var latitude = coordinates.lat;
        var longitude = coordinates.lng;
        var result =  (await this._weatherService.GetWeatherByCoordinates(latitude, longitude)).subscribe((response: any) => {
            var weatherResponse = response;
        })
    }


}
