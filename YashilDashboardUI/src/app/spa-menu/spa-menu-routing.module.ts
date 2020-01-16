import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {SpaIndexComponent} from './pages/spa-index/spa-index.component';
import {AuthGuard} from 'yashil-core';
import {ReportViewerComponent} from '../report/report-viewer/report-viewer.component';


const routes: Routes = [
  {path: '', component: SpaIndexComponent, canActivate: [AuthGuard]},
  {path: 'viewReport/:id', component: ReportViewerComponent, canActivate: [AuthGuard]}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SpaMenuRoutingModule {
}
