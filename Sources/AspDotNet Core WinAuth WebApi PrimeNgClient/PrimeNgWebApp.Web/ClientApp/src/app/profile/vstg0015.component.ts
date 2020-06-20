import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../_services/identity.service';

@Component({
    selector: 'app-profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
    identity: any = {};
    errorMessage: string;

    constructor(private idService: IdentityService) {}

    ngOnInit(): void {
        this.idService.getForecast().subscribe({
            next: (data) => {
                this.identity = data;
                console.info ('Identity: ' + JSON.stringify(data));
            },
            error: (err) => (this.errorMessage = err),
        });
    }
}
