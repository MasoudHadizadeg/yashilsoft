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
            {path: 'um', loadChildren: () => import('../user-management/user-management.module').then(m => m.UserManagementModule)},
            {path: 'dash', loadChildren: () => import('../dashboard/dashboard.module').then(m => m.DashboardModule)},
            {path: 'rpt', loadChildren: () => import('../report/report.module').then(m => m.ReportModule)},
            {path: 'base', loadChildren: () => import('../base-info/base-info.module').then(m => m.BaseInfoModule)},
            {path: 'dms', loadChildren: () => import('../dms/dms.module').then(m => m.DmsModule)},
            {path: 'tms', loadChildren: () => import('../tms/tms.module').then(m => m.TmsModule)},
            {path: 'news', loadChildren: () => import('../news/news.module').then(m => m.NewsModule)}
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
