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
        var latitude = coordinates.lat;
        var longitude = coordinates.lng;
        this.ShowSpinner(10000);
        this._weatherService.GetWeatherByCoordinates(latitude, longitude)
            .subscribe((response: WeatherModel) => {
                this.weather = response;
                this.ShowSpinner(0);
            });
    }


    ShowSpinner(seconds: number) {
        this.spinner.show();
        setTimeout(() => {
            this.spinner.hide();
        }, seconds);
    }
}
