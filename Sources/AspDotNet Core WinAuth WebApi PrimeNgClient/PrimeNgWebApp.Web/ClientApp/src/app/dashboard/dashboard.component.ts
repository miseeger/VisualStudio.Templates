import { Component, OnInit } from '@angular/core';
import { IStatistics } from '../_interfaces/istatistics';
import { ITopTrack } from '../_interfaces/itoptrack';
import { DashboardService } from '../_services/dashboard.service';


@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
    statistics: IStatistics = {
        albumCount: 0,
        songCount: 0,
        artistCount: 0,
        playLength: 0 };
    top3: ITopTrack[];
    errorMessage: string;

    constructor(private dService: DashboardService) {}

    ngOnInit(): void {
        this.dService.getStatistics().subscribe({
            next: (data) => {this.statistics = data;},
            error: (err) => (this.errorMessage = err),
        });
        this.dService.getTop3().subscribe({
            next: (data) => {this.top3 = data;},
            error: (err) => (this.errorMessage = err),
        });
    }
}
