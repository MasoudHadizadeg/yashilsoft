import {Component} from '@angular/core';
import {ReportStoreDetailComponent} from './report-store-detail.component';

@Component({
    selector: 'app-report-store-list',
    templateUrl: './report-store-list.component.html'
})
export class ReportStoreListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'reportStore';
    detailComponent = ReportStoreDetailComponent;

    constructor() {
        this.columns.push({
            caption: 'عنوان',
            dataField: 'title'
        });
        this.columns.push({
            caption: 'کلید گزارش',
            dataField: 'reportKey'
        });
        this.columns.push({
            caption: 'ماژول',
            dataField: 'moduleKey'
        });
        this.columns.push({
            caption: 'سطح دسترسی',
            dataField: 'accessLevelTitle'
        });

    }
}
