import { Component, OnInit } from '@angular/core';
import { WeatherforecastService } from '../_services/weatherforecast.service';
import { IWeatherforecast } from '../_interfaces/iweatherforecast';

@Component({
    selector: 'app-weather',
    templateUrl: './weather.component.html',
    styleUrls: ['./weather.component.css'],
})
export class WeatherComponent implements OnInit {
    cols: any[];
    first = 0;
    rows = 5;
    forecasts: IWeatherforecast[];
    errorMessage: string;

    constructor(private wfService: WeatherforecastService) {}

    ngOnInit(): void {
        this.cols = [
            { field: 'date', header: 'Day' },
            { field: 'temperatureC', header: 'Temp [°C]' },
            { field: 'temperatureF', header: 'Temp [°F]' },
            { field: 'summary', header: 'Summary' },
        ];

        this.wfService.getForecast().subscribe({
            next: (forecasts) => (this.forecasts = forecasts),
            error: (err) => (this.errorMessage = err),
        });
    }

    next() {
        this.first = this.first + this.rows;
    }

    prev() {
        this.first = this.first - this.rows;
    }

    reset() {
        this.first = 0;
    }

    isLastPage(): boolean {
        return this.first === (this.forecasts.length || 0) - this.rows;
    }

    isFirstPage(): boolean {
        return this.first === 0;
    }
}
