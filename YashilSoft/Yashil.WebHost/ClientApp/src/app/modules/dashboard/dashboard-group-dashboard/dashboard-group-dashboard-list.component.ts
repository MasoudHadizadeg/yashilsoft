import {Component, OnInit} from '@angular/core';
import {DashboardGroupDashboardDetailComponent} from './dashboard-group-dashboard-detail.component';

@Component({
    selector: 'app-dashboard-group-dashboard-list',
    templateUrl: './dashboard-group-dashboard-list.component.html'
})
export class DashboardGroupDashboardListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'dashboardGroupDashboard';
    detailComponent = DashboardGroupDashboardDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'گروه داشبورد',
            dataField: 'dashboardGroupTitle',
            groupIndex: 1
        });
        this.columns.push({
            caption: 'داشبورد',
            dataField: 'dashboardStoreTitle'
        });

    }
}
