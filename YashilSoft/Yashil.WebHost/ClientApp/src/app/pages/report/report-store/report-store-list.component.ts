import {Component} from '@angular/core';
import {ReportStoreDetailComponent} from './report-store-detail.component';
import {Router} from '@angular/router';

@Component({
    selector: 'app-report-store-list',
    templateUrl: './report-store-list.component.html'
})
export class ReportStoreListComponent {
    selectedItemId: number;
    columns: any[] = [];
    entityName = 'reportStore';
    detailComponent = ReportStoreDetailComponent;

    constructor(private router: Router) {
        this.DesignReport = this.DesignReport.bind(this);
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
        this.columns.push({
            type: 'buttons',
            width: 50,
            buttons: [
                {
                    hint: '  طراحی گزارش',
                    icon: 'chart',
                    onClick: this.DesignReport
                }]
        });
    }

    DesignReport(e) {
        const selectedReportId = e.row.data.Id;
        this.router.navigate(['pages/rpt/designReport', e.row.data.id]);
    }
}
