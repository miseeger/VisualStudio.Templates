import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IWeatherforecast } from '../_interfaces/iweatherforecast';
import { handleError } from '../app.utils';

@Injectable({
    providedIn: 'root',
})
export class WeatherforecastService {
    private readonly _baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    getForecast(): Observable<IWeatherforecast[]> {
        return this.http
            .get<IWeatherforecast[]>(this._baseUrl + 'api/weatherforecast')
            .pipe(
                tap((data) => console.log('Forecast: ' + JSON.stringify(data))),
                catchError(handleError)
            );
    }
}
