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

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StatisticComponent } from './statistic/statistic.component';
import { ProfileComponent } from './profile/profile.component';
import { WeatherComponent } from './weather/weather.component';
import { CustomersComponent } from './customers/customers.component';
import { AboutComponent } from './about/about.component';

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
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        BrowserAnimationsModule,
        RouterModule.forRoot(appRoutes),
        HttpClientModule,
        MenuModule,
        PanelModule,
        TabViewModule,
        AccordionModule,
        TableModule,
        ButtonModule,
        CardModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
