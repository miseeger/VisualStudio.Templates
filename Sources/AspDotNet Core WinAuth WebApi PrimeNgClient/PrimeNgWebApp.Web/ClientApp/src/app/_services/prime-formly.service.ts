import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class PrimeFormlyService {
    constructor() {}

    getNations() {
        return of([
            { value: null, label: 'none' },
            { value: 1, label: 'Germany' },
            { value: 2, label: 'Italy' },
            { value: 3, label: 'U. S.' },
        ]);
    }

    getCities(nationId: number = null) {
        return of(
            [
                { value: null, label: 'none', nationId: null },
                { value: 1, label: 'Bolzano', nationId: 2 },
                { value: 2, label: 'Rome', nationId: 2 },
                { value: 3, label: 'Frankfurt', nationId: 1 },
                { value: 4, label: 'Berlin', nationId: 1 },
                { value: 5, label: 'San Francisco', nationId: 3 },
                { value: 6, label: 'New York', nationId: 3 },
            ].filter((entry) => {
                if (nationId) {
                    return entry.nationId === nationId;
                } else {
                    return entry.nationId === null;
                }
            })
        );
    }
}
