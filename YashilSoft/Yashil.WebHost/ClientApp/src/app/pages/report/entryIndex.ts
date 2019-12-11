import {ReportGroupDetailComponent} from './report-group/report-group-detail.component';
import {ReportConnectionStringDetailComponent} from './report-connection-string/report-connection-string-detail.component';
import {RoleReportDetailComponent} from './role-report/role-report-detail.component';
import {ReportStoreDetailComponent} from './report-store/report-store-detail.component';
import {UserReportDetailComponent} from './user-report/user-report-detail.component';
import {ReportGroupReportDetailComponent} from './report-group-report/report-group-report-detail.component';
import {Provider} from '@angular/core';

export const ENTRYCOMPONENTS: Provider[] = [
    ReportGroupDetailComponent,
    ReportConnectionStringDetailComponent,
    RoleReportDetailComponent,
    ReportStoreDetailComponent,
    UserReportDetailComponent,
    ReportGroupReportDetailComponent
];
