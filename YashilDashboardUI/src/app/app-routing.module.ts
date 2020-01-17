import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {NotFoundComponent} from './shared/components/not-found/not-found.component';
import {ContentLayoutComponent} from './layouts/content/content-layout.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import(`./modules/spa-menu/spa-menu.module`).then(m => m.SpaMenuModule)
  },
  {
    path: '404',
    component: NotFoundComponent
  },
  {
    path: 'pages', component: ContentLayoutComponent,
    children: [
      {path: '', loadChildren: () => import('./modules/content-pages/content-pages.module').then(m => m.ContentPagesModule)},
      {path: 'dash', loadChildren: () => import('./modules/dev-dashboard/dev-dashboard.module').then(m => m.DevDashboardModule)},
      {path: 'rpt', loadChildren: () => import('./modules/report/stimulsoft-report.module').then(m => m.StimulsoftReportModule)}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
