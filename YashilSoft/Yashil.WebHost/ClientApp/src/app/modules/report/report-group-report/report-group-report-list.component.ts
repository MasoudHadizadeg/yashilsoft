import {Component} from '@angular/core';
import {ReportGroupReportDetailComponent} from './report-group-report-detail.component';

@Component({
    selector: 'app-report-group-report-list',
    templateUrl: './report-group-report-list.component.html'
})
export class ReportGroupReportListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'reportGroupReport';
    detailComponent = ReportGroupReportDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'گروه گزارش',
            dataField: 'reportGroupTitle',
            groupIndex: 1
        });
        this.columns.push({
            caption: 'گزارش',
            dataField: 'reportStoreTitle'
        });
    }
}
