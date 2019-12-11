import {HomeComponent} from './home/home.component';
import {FullLayoutComponent} from '../../layouts/full/full-layout.component';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {NgModule} from '@angular/core';

const routes: Routes = [
    {
        path: '',
        component: FullLayoutComponent,
        children: [
            {path: '', component: HomeComponent, canActivate: [AuthGuard]},
            {path: 'um', loadChildren: '../user-management/user-management.module#UserManagementModule'},
            {path: 'dash', loadChildren: '../dashboard/dashboard.module#DashboardModule'},
            {path: 'rpt', loadChildren: '../report/report.module#ReportModule'},
            {path: 'base', loadChildren: '../base-info/base-info.module#BaseInfoModule'},
        ]
    }
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class FullPagesRoutingModule {

}
