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

    public canvasWidth = 350;
    public needleValue = 20;
    public centralLabel = '';
    public name = 'Temperature';
    public bottomLabel = '65';
    public options = {
        hasNeedle: true,
        needleColor: 'white',
        needleUpdateSpeed: 1000,
        arcColors: ['rgb(61,204,91)', 'rgb(239,214,19)', 'rgb(255,84,84)'],
        arcDelimiters: [30, 60],
        rangeLabel: ['0', '45+'],
        needleStartValue: 15,
    };


    constructor(private _weatherService: WeatherService, private spinner: NgxSpinnerService) { }

    GetWeatherByClick(coordinates) {
        this.ShowSpinner(2000);

        var latitude = coordinates.lat;
        var longitude = coordinates.lng;
        this._weatherService.GetWeatherByCoordinates(latitude, longitude).then((response: WeatherModel) => {
            this.ShowSpinner(2000);
            this.weather = response;
            this.needleValue = this.weather.environment.temp * 100 / 45;
            this.bottomLabel = this.weather.environment.temp.toString();

        });
    }


    ShowSpinner(seconds: number) {
        this.spinner.show();
        setTimeout(() => {
            this.spinner.hide();
        }, seconds);
    }
}
