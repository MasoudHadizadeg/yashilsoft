import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {DashboardViewerComponent} from './dashboard-viewer/dashboard-viewer.component';
import {AuthGuard} from 'yashil-core';

const routes: Routes = [
    {path: ':id', component: DashboardViewerComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class DevDashboardRoutingModule {

}
