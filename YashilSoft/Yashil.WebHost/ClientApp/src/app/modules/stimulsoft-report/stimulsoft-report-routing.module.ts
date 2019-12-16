import {ReportViewerComponent} from './stimulsoft/report-viewer/report-viewer.component';
import {RouterModule, Routes} from '@angular/router';
import {ReportDesignerComponent} from './stimulsoft/report-designer/report-designer.component';
import {NgModule} from '@angular/core';
import {AuthGuard} from '../../shared/_guards';

const routes: Routes = [
    {path: 'designReport/:id', component: ReportDesignerComponent, canActivate: [AuthGuard]},
    {path: 'viewReport/:id', component: ReportViewerComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class StimulsoftReportRoutingModule {

}
