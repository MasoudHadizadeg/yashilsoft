import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {AuthGuard} from '../../shared/_guards';
import {DashboardDesignerComponent} from './dashboard-designer/dashboard-designer.component';
import {DashboardViewerComponent} from './dashboard-viewer/dashboard-viewer.component';

const routes: Routes = [
    {path: 'designDashboard/:id', component: DashboardDesignerComponent, canActivate: [AuthGuard]},
    {path: 'viewDashboard/:id', component: DashboardViewerComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class DevDashboardRoutingModule {

}
