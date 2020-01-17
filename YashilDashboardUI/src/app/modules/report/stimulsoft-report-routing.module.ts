import {ReportViewerComponent} from './report-viewer/report-viewer.component';
import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {AuthGuard} from 'yashil-core';

const routes: Routes = [
    {path: ':id', component: ReportViewerComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class StimulsoftReportRoutingModule {

}
