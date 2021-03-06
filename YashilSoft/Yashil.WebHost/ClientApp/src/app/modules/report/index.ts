import {ReportGroupDetailComponent} from './report-group/report-group-detail.component';
import {ReportGroupListComponent} from './report-group/report-group-list.component';
import {RoleReportDetailComponent} from './role-report/role-report-detail.component';
import {RoleReportListComponent} from './role-report/role-report-list.component';
import {ReportStoreDetailComponent} from './report-store/report-store-detail.component';
import {ReportStoreListComponent} from './report-store/report-store-list.component';
import {UserReportDetailComponent} from './user-report/user-report-detail.component';
import {UserReportListComponent} from './user-report/user-report-list.component';
import {ReportGroupReportDetailComponent} from './report-group-report/report-group-report-detail.component';
import {ReportGroupReportListComponent} from './report-group-report/report-group-report-list.component';
import {Provider} from '@angular/core';
export const COMPONENTS: Provider[] = [
    ReportGroupListComponent,
    ReportGroupDetailComponent,
    RoleReportListComponent,
    RoleReportDetailComponent,
    ReportStoreListComponent,
    ReportStoreDetailComponent,
    UserReportListComponent,
    UserReportDetailComponent,
    ReportGroupReportListComponent,
    ReportGroupReportDetailComponent
];
