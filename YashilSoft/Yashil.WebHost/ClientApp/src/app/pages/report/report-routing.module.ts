import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {ReportGroupListComponent} from './report-group/report-group-list.component';
import {ReportConnectionStringListComponent} from './report-connection-string/report-connection-string-list.component';
import {RoleReportListComponent} from './role-report/role-report-list.component';
import {ReportStoreListComponent} from './report-store/report-store-list.component';
import {UserReportListComponent} from './user-report/user-report-list.component';
import {ReportGroupReportListComponent} from './report-group-report/report-group-report-list.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
    {path: 'reportGroups', component: ReportGroupListComponent, canActivate: [AuthGuard]},
    {path: 'reportConnectionStrings', component: ReportConnectionStringListComponent, canActivate: [AuthGuard]},
    {path: 'roleReports', component: RoleReportListComponent, canActivate: [AuthGuard]},
    {path: 'reportStores', component: ReportStoreListComponent, canActivate: [AuthGuard]},
    {path: 'userReports', component: UserReportListComponent, canActivate: [AuthGuard]},
    {path: 'reportGroupReports', component: ReportGroupReportListComponent, canActivate: [AuthGuard]},
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class ReportRoutingModule {

}
