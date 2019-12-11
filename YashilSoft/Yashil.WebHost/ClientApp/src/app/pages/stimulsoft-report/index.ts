import {ReportGroupDetailComponent} from './report-group/report-group-detail.component';
import {ReportGroupListComponent} from './report-group/report-group-list.component';
import {ReportConnectionStringDetailComponent} from './report-connection-string/report-connection-string-detail.component';
import {ReportConnectionStringListComponent} from './report-connection-string/report-connection-string-list.component';
import {RoleReportDetailComponent} from './role-report/role-report-detail.component';
import {RoleReportListComponent} from './role-report/role-report-list.component';
import {ReportStoreDetailComponent} from './report-store/report-store-detail.component';
import {ReportStoreListComponent} from './report-store/report-store-list.component';
import {UserReportDetailComponent} from './user-report/user-report-detail.component';
import {UserReportListComponent} from './user-report/user-report-list.component';
import {ReportGroupReportDetailComponent} from './report-group-report/report-group-report-detail.component';
import {ReportGroupReportListComponent} from './report-group-report/report-group-report-list.component';
import {Provider} from '@angular/core';
import {ReportViewerComponent} from './stimulsoft/report-viewer/report-viewer.component';
import {ReportDesignerComponent} from './stimulsoft/report-designer/report-designer.component';

export const COMPONENTS: Provider[] = [
    ReportDesignerComponent,
    ReportViewerComponent,
    ReportGroupListComponent,
    ReportGroupDetailComponent,
    ReportConnectionStringListComponent,
    ReportConnectionStringDetailComponent,
    RoleReportListComponent,
    RoleReportDetailComponent,
    ReportStoreListComponent,
    ReportStoreDetailComponent,
    UserReportListComponent,
    UserReportDetailComponent,
    ReportGroupReportListComponent,
    ReportGroupReportDetailComponent
];
