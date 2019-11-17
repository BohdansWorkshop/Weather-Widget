import { Component } from '@angular/core';
import { WeatherService } from './services/weather.service';
import { WeatherModel } from './models/weather.model';
import { NgxSpinnerService } from 'ngx-spinner';

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

    constructor(private _weatherService: WeatherService, private spinner: NgxSpinnerService) { }

    GetWeatherByClick(coordinates) {
        this.ShowSpinner(2000);

        var latitude = coordinates.lat;
        var longitude = coordinates.lng;
        this._weatherService.GetWeatherByCoordinates(latitude, longitude).then((response: WeatherModel) => {
            this.ShowSpinner(2000);
            this.weather = response;
        });
    }


    ShowSpinner(seconds: number) {
        this.spinner.show();
        setTimeout(() => {
            this.spinner.hide();
        }, seconds);
    }
}
