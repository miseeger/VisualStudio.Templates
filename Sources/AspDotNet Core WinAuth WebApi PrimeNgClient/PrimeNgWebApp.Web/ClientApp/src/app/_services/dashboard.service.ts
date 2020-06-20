import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { handleError } from '../app.utils';
import { IStatistics } from '../_interfaces/istatistics';
import { ITopTrack } from '../_interfaces/itoptrack';

@Injectable({
    providedIn: 'root',
})
export class DashboardService {
    private readonly _baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    getStatistics(): Observable<IStatistics> {
        return this.http
            .get<IStatistics>(this._baseUrl + 'api/dashboard/statistics')
            .pipe(
                tap((data) => console.log('Statistics: ' + data)),
                catchError(handleError)
            );
    }

    getTop3(): Observable<ITopTrack[]> {
        return this.http
            .get<ITopTrack[]>(this._baseUrl + 'api/dashboard/top3tracks')
            .pipe(
                tap((data) => console.log('Top Tracks: ' + data)),
                catchError(handleError)
            );
    }
}
