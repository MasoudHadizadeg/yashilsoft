import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {SpaIndexComponent} from './pages/spa-index/spa-index.component';
import {AuthGuard} from 'yashil-core';
import {ContentLayoutComponent} from '../../layouts/content/content-layout.component';

const routes: Routes = [
  {path: '', component: SpaIndexComponent, canActivate: [AuthGuard]},
  {
    path: 'view',
    component: ContentLayoutComponent,
    children: [
      {path: 'Dashboard', loadChildren: () => import('../dev-dashboard/dev-dashboard.module').then(m => m.DevDashboardModule)},
      {path: 'Report', loadChildren: () => import('../report/stimulsoft-report.module').then(m => m.StimulsoftReportModule)},
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SpaMenuRoutingModule {
}
