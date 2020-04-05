import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-customer-api',
  templateUrl: './customer-api.component.html',
})
export class CustomerApiComponent {
  public customers: Customer[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Customer[]>(baseUrl + 'api/customers').subscribe(
      (result) => {
        this.customers = result;
      },
      (error) => console.error(error)
    );
  }
}

interface Customer {
  id?: string;
  companyName?: string;
  contactName?: string;
  contactTitle?: string;
  address?: string;
  region?: string;
  postalCode?: string;
  country?: string;
  phone?: string;
  fax?: string;
}
