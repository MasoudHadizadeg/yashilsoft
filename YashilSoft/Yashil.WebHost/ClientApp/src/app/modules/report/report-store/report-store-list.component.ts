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
        this.ViewReport = this.ViewReport.bind(this);
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
            caption: 'نمایش/طراحی  گزارش',
            type: 'buttons',
            width: 130,
            buttons: [
                {
                    hint: 'طراحی ',
                    icon: 'chart',
                    onClick: this.DesignReport
                },
                {
                    hint: 'نمایش ',
                    icon: 'columnchooser',
                    onClick: this.ViewReport
                }]
        });
    }

    DesignReport(e) {
        const selectedReportId = e.row.data.Id;
        this.router.navigate(['modules/rpt/designReport', e.row.data.id]);
    }

    ViewReport(e) {
        const selectedReportId = e.row.data.Id;
        this.router.navigate(['modules/rpt/viewReport', e.row.data.id]);
    }
}
