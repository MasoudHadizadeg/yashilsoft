import {Component} from '@angular/core';
import {DashboardStoreDetailComponent} from './dashboard-store-detail.component';
import {Router} from '@angular/router';

@Component({
    selector: 'app-dashboard-store-list',
    templateUrl: './dashboard-store-list.component.html'
})
export class DashboardStoreListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'dashboardStore';
    detailComponent = DashboardStoreDetailComponent;

    constructor(private router: Router) {
        this.DesignDashboard = this.DesignDashboard.bind(this);
        this.ViewDashboard = this.ViewDashboard.bind(this);

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
        this.columns.push({
            caption: 'نمایش/طراحی  داشبورد',
            type: 'buttons',
            width: 130,
            buttons: [
                {
                    hint: 'طراحی ',
                    icon: 'chart',
                    onClick: this.DesignDashboard
                },
                {
                    hint: 'نمایش ',
                    icon: 'columnchooser',
                    onClick: this.ViewDashboard
                }]

        });
    }

    DesignDashboard(e) {
        const selectedDashboardId = e.row.data.Id;
        this.router.navigate(['pages/dash/designDashboard', e.row.data.id]);
    }

    ViewDashboard(e) {
        const selectedDashboardId = e.row.data.Id;
        this.router.navigate(['pages/dash/viewDashboard', e.row.data.id]);
    }
}
