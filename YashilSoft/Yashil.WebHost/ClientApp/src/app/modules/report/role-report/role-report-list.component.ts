import {Component} from '@angular/core';
import {RoleReportDetailComponent} from './role-report-detail.component';

@Component({
    selector: 'app-role-report-list',
    templateUrl: './role-report-list.component.html'
})
export class RoleReportListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'roleReport';
    detailComponent = RoleReportDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'نقش',
            dataField: 'roleTitle',
            groupIndex: 1
        });
        this.columns.push({
            caption: 'گزارش',
            dataField: 'reportTitle'
        });

    }
}
