import {Component} from '@angular/core';
import {DashboardStoreDetailComponent} from './dashboard-store-detail.component';

@Component({
    selector: 'app-dashboard-store-list',
    templateUrl: './dashboard-store-list.component.html'
})
export class DashboardStoreListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'dashboardStore';
    detailComponent = DashboardStoreDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'کد',
            dataField: 'code'
        });
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'سطح دسترسی',
            dataField: 'accessLevelTitle'
        });

    }
}
