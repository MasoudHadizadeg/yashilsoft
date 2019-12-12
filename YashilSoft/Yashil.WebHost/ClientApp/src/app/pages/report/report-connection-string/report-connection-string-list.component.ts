import {Component} from '@angular/core';
import {ReportConnectionStringDetailComponent} from './report-connection-string-detail.component';

@Component({
    selector: 'app-report-connection-string-list',
    templateUrl: './report-connection-string-list.component.html'
})
export class ReportConnectionStringListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'reportConnectionString';
    detailComponent = ReportConnectionStringDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'گزارش',
            dataField: 'reportTitle',
            groupIndex: 1
        });
        this.columns.push({
            caption: 'رشته اتصال',
            dataField: 'connectionStringTitle'
        });

    }
}
