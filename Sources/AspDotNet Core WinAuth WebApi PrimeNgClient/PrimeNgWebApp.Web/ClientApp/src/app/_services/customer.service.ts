import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ICustomer } from '../_interfaces/icustomer';
import { handleError } from '../app.utils';

@Injectable({
    providedIn: 'root',
})
export class CustomerService {
    private readonly _baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    getCustomers(): Observable<ICustomer[]> {
        return this.http
            .get<ICustomer[]>(this._baseUrl + 'api/customer')
            .pipe(
                tap((data) => console.log('Customers: ' + JSON.stringify(data))),
                catchError(handleError)
            );
    }
}
