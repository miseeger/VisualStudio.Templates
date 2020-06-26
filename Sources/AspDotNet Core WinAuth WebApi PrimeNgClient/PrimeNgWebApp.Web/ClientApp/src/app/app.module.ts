import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MenuModule } from 'primeng/menu';
import { PanelModule } from 'primeng/panel';
import { TabViewModule } from 'primeng/tabview';
import { AccordionModule } from 'primeng/accordion';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { SelectButtonModule } from 'primeng/selectbutton';
import { MultiSelectModule } from 'primeng/multiselect';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StatisticComponent } from './statistic/statistic.component';
import { ProfileComponent } from './profile/profile.component';
import { WeatherComponent } from './weather/weather.component';
import { CustomersComponent } from './customers/customers.component';
import { AboutComponent } from './about/about.component';

import { PrimeSelectButtonComponent } from './_formly/p-select-button.type';
import { PrimeMultiSelectComponent } from './_formly/p-multi-select.type';

import { ReactiveFormsModule } from '@angular/forms';
import { FormlyModule, FormlyFieldConfig } from '@ngx-formly/core';
import { FormlyPrimeNGModule } from '@ngx-formly/primeng';
import { PrimeFormlyComponent } from './prime-formly/prime-formly.component';
import { ipValidator, ipValidationMessage } from './_formly/ip.validator';

const appRoutes: Routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    {
        path: 'dashboard',
        component: DashboardComponent,
    },
    {
        path: 'customers',
        component: CustomersComponent,
    },
    {
        path: 'weather',
        component: WeatherComponent,
    },
    {
        path: 'formly',
        component: PrimeFormlyComponent,
    },
    {
        path: 'profile',
        component: ProfileComponent,
    },
    {
        path: 'about',
        component: AboutComponent,
    },
];

@NgModule({
    declarations: [
        AppComponent,
        DashboardComponent,
        StatisticComponent,
        ProfileComponent,
        WeatherComponent,
        CustomersComponent,
        AboutComponent,
        PrimeFormlyComponent,
        PrimeSelectButtonComponent,
        PrimeMultiSelectComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        BrowserAnimationsModule,
        RouterModule.forRoot(appRoutes),
        HttpClientModule,
        ReactiveFormsModule,
        FormlyPrimeNGModule,
        FormlyModule.forRoot({
            types: [
                {
                    name: 'selectbutton',
                    component: PrimeSelectButtonComponent,
                },
                {
                    name: 'multiselect',
                    component: PrimeMultiSelectComponent,
                },
            ],
            validators: [
                {
                    name: 'ip',
                    validation: ipValidator,
                },
            ],
            validationMessages: [
                {
                    name: 'required',
                    message: 'This field is required!',
                },
                {
                    name: 'min',
                    message: (err, field: FormlyFieldConfig) => {
                        return `Please provide a value greater than ${
                            err.min - 1
                        } for ${field.templateOptions.label}. You provided ${
                            err.actual
                        }.`;
                    },
                },
                {
                    name: 'ip',
                    message: ipValidationMessage,
                },
            ],
        }),
        MenuModule,
        PanelModule,
        TabViewModule,
        AccordionModule,
        TableModule,
        ButtonModule,
        CardModule,
        SelectButtonModule,
        MultiSelectModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
