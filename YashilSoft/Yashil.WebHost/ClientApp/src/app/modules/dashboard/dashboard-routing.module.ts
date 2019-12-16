

import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
				import {DashboardConnectionStringListComponent} from './dashboard-connection-string/dashboard-connection-string-list.component';
								import {UserDashboardListComponent} from './user-dashboard/user-dashboard-list.component';
								import {RoleDashboardListComponent} from './role-dashboard/role-dashboard-list.component';
								import {DashboardGroupListComponent} from './dashboard-group/dashboard-group-list.component';
								import {DashboardStoreListComponent} from './dashboard-store/dashboard-store-list.component';
								import {DashboardGroupDashboardListComponent} from './dashboard-group-dashboard/dashboard-group-dashboard-list.component';
				import {FullLayoutSplitComponent} from '../../layouts/fullsplit/full-layout-split.component';
import {NgModule} from '@angular/core';
const routes: Routes = [    
					{path: 'dashboardConnectionStrings', component: DashboardConnectionStringListComponent, canActivate: [AuthGuard]},		  
					{path: 'userDashboards', component: UserDashboardListComponent, canActivate: [AuthGuard]},		  
					{path: 'roleDashboards', component: RoleDashboardListComponent, canActivate: [AuthGuard]},		  
					{path: 'dashboardGroups', component: DashboardGroupListComponent, canActivate: [AuthGuard]},		  
					{path: 'dashboardStores', component: DashboardStoreListComponent, canActivate: [AuthGuard]},		  
					{path: 'dashboardGroupDashboards', component: DashboardGroupDashboardListComponent, canActivate: [AuthGuard]}		  
	];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class DashboardRoutingModule {

}
