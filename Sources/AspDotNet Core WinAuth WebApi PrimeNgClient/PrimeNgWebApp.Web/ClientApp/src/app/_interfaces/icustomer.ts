export interface ICustomer {
    customerId: number;
    firstName: string;
    lastName: string;
    company: string;
    address: string;
    city: string;
    state: string;
    country: string;
    postalCode: string;
    phone: string;
    fax: string;
    email: string;
    supportRepId: number;
    supportRepName?: any;
    invoices?: any;
    supportRep?: any;
}
