import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Router, RouterOutlet } from '@angular/router';
import { routerAnimation } from './router.animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [routerAnimation],
})
export class AppComponent implements OnInit {
  menuItems: MenuItem[];
  miniMenuItems: MenuItem[];

  constructor() {}

  prepareRoute(outlet: RouterOutlet) {
    return outlet && outlet.activatedRouteData;
  }

  ngOnInit() {
    this.menuItems = [
        {
            label: 'Dashboard',
            icon: 'fa fa-home',
            routerLink: ['/dashboard'],
            routerLinkActiveOptions: { exact: true },
        },
        {
            label: 'Customers',
            icon: 'fa fa-users',
            routerLink: ['/customers'],
            routerLinkActiveOptions: { exact: true },
        },
        {
            label: 'Weatherforecast',
            icon: 'fa fa-cloud',
            routerLink: ['/weather'],
            routerLinkActiveOptions: { exact: true },
        },
        {
            label: 'Formly PrimeNG',
            icon: 'fa fa-file-text-o',
            routerLink: ['/formly'],
            routerLinkActiveOptions: { exact: true },
        },
        {
            label: 'My Profile',
            icon: 'fa fa-user-circle',
            routerLink: ['/profile'],
            routerLinkActiveOptions: { exact: true },
        },
        {
            label: 'About',
            icon: 'fa fa-info-circle',
            routerLink: ['/about'],
            routerLinkActiveOptions: { exact: true },
        },
    ];

    this.miniMenuItems = [];
    this.menuItems.forEach((item: MenuItem) => {
      const miniItem = {
        icon: item.icon,
        routerLink: item.routerLink,
        title: item.label,
      };
      this.miniMenuItems.push(miniItem);
    });
  }
}
