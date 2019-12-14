import {Component} from '@angular/core';
import {DashboardConnectionStringDetailComponent} from './dashboard-connection-string-detail.component';

@Component({
    selector: 'app-dashboard-connection-string-list',
    templateUrl: './dashboard-connection-string-list.component.html'
})
export class DashboardConnectionStringListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'dashboardConnectionString';
    detailComponent = DashboardConnectionStringDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'داشبورد',
            dataField: 'dashboardTitle'
        });
        this.columns.push({
            caption: 'رشته اتصال',
            dataField: 'connectionStringTitle'
        });

    }
}
