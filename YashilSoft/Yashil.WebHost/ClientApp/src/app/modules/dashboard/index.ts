

import {Routes} from '@angular/router';
				import {DashboardConnectionStringDetailComponent} from './dashboard-connection-string/dashboard-connection-string-detail.component';
				import {DashboardConnectionStringListComponent} from './dashboard-connection-string/dashboard-connection-string-list.component';
								import {UserDashboardDetailComponent} from './user-dashboard/user-dashboard-detail.component';
				import {UserDashboardListComponent} from './user-dashboard/user-dashboard-list.component';
								import {RoleDashboardDetailComponent} from './role-dashboard/role-dashboard-detail.component';
				import {RoleDashboardListComponent} from './role-dashboard/role-dashboard-list.component';
								import {DashboardGroupDetailComponent} from './dashboard-group/dashboard-group-detail.component';
				import {DashboardGroupListComponent} from './dashboard-group/dashboard-group-list.component';
								import {DashboardStoreDetailComponent} from './dashboard-store/dashboard-store-detail.component';
				import {DashboardStoreListComponent} from './dashboard-store/dashboard-store-list.component';
								import {DashboardGroupDashboardDetailComponent} from './dashboard-group-dashboard/dashboard-group-dashboard-detail.component';
				import {DashboardGroupDashboardListComponent} from './dashboard-group-dashboard/dashboard-group-dashboard-list.component';
							import {Provider} from '@angular/core';
			 
				export const COMPONENTS:Provider[]=[
				 
			  DashboardConnectionStringListComponent,
		  DashboardConnectionStringDetailComponent ,		  
			  UserDashboardListComponent,
		  UserDashboardDetailComponent ,		  
			  RoleDashboardListComponent,
		  RoleDashboardDetailComponent ,		  
			  DashboardGroupListComponent,
		  DashboardGroupDetailComponent ,		  
			  DashboardStoreListComponent,
		  DashboardStoreDetailComponent ,		  
			  DashboardGroupDashboardListComponent,
		  DashboardGroupDashboardDetailComponent 		  
		];
