import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { handleError } from '../app.utils';

@Injectable({
    providedIn: 'root',
})
export class IdentityService {
    private readonly _baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    getForecast(): Observable<any> {
        return this.http.get<any>(this._baseUrl + 'api/identity/me').pipe(
            tap((data) => console.log('Identity: ' + data)),
            catchError(handleError)
        );
    }
}
