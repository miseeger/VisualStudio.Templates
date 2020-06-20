import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../_services/customer.service';
import { ICustomer } from '../_interfaces/icustomer';
import {
    trigger,
    state,
    style,
    transition,
    animate,
} from '@angular/animations';
import { FilterUtils } from 'primeng/utils';

@Component({
    selector: 'app-customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.css'],
    animations: [
        trigger('rowExpansionTrigger', [
            state(
                'void',
                style({
                    transform: 'translateX(-10%)',
                    opacity: 0,
                })
            ),
            state(
                'active',
                style({
                    transform: 'translateX(0)',
                    opacity: 1,
                })
            ),
            transition(
                '* <=> *',
                animate('400ms cubic-bezier(0.86, 0, 0.07, 1)')
            ),
        ]),
    ],
})
export class CustomersComponent implements OnInit {
    cols: any[];
    customers: ICustomer[];
    errorMessage: string;

    constructor(private cstService: CustomerService) {
        FilterUtils['custom'] = (value, filter): boolean => {
            if (
                filter === undefined ||
                filter === null ||
                filter.trim() === ''
            ) {
                return true;
            }

            if (value === undefined || value === null) {
                return false;
            }

            return parseInt(filter, 10) > value;
        };
    }

    ngOnInit(): void {
        this.cols = [
            { field: 'lastName', header: 'Lastname' },
            { field: 'firstName', header: 'Firstname' },
            { field: 'company', header: 'Company' },
            { field: 'city', header: 'City' },
        ];

        this.cstService.getCustomers().subscribe({
            next: (customers) => (this.customers = customers),
            error: (err) => (this.errorMessage = err),
        });
    }
}
