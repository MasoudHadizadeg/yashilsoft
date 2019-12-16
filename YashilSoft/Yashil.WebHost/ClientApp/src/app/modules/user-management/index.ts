

import {Routes} from '@angular/router';
				import {ResourceDetailComponent} from './resource/resource-detail.component';
				import {ResourceListComponent} from './resource/resource-list.component';
								import {ApplicationDetailComponent} from './application/application-detail.component';
				import {ApplicationListComponent} from './application/application-list.component';
								import {OrganizationDetailComponent} from './organization/organization-detail.component';
				import {OrganizationListComponent} from './organization/organization-list.component';
								import {AppActionDetailComponent} from './app-action/app-action-detail.component';
				import {AppActionListComponent} from './app-action/app-action-list.component';
								import {ResourceAppActionDetailComponent} from './resource-app-action/resource-app-action-detail.component';
				import {ResourceAppActionListComponent} from './resource-app-action/resource-app-action-list.component';
								import {RoleResourceActionDetailComponent} from './role-resource-action/role-resource-action-detail.component';
				import {RoleResourceActionListComponent} from './role-resource-action/role-resource-action-list.component';
								import {AppConfigDetailComponent} from './app-config/app-config-detail.component';
				import {AppConfigListComponent} from './app-config/app-config-list.component';
								import {UserDetailComponent} from './user/user-detail.component';
				import {UserListComponent} from './user/user-list.component';
								import {RoleDetailComponent} from './role/role-detail.component';
				import {RoleListComponent} from './role/role-list.component';
								import {MenuDetailComponent} from './menu/menu-detail.component';
				import {MenuListComponent} from './menu/menu-list.component';
								import {UserRoleDetailComponent} from './user-role/user-role-detail.component';
				import {UserRoleListComponent} from './user-role/user-role-list.component';
							import {Provider} from '@angular/core';
			 
				export const COMPONENTS:Provider[]=[
				 
			  ResourceListComponent,
		  ResourceDetailComponent ,		  
			  ApplicationListComponent,
		  ApplicationDetailComponent ,		  
			  OrganizationListComponent,
		  OrganizationDetailComponent ,		  
			  AppActionListComponent,
		  AppActionDetailComponent ,		  
			  ResourceAppActionListComponent,
		  ResourceAppActionDetailComponent ,		  
			  RoleResourceActionListComponent,
		  RoleResourceActionDetailComponent ,		  
			  AppConfigListComponent,
		  AppConfigDetailComponent ,		  
			  UserListComponent,
		  UserDetailComponent ,		  
			  RoleListComponent,
		  RoleDetailComponent ,		  
			  MenuListComponent,
		  MenuDetailComponent ,		  
			  UserRoleListComponent,
		  UserRoleDetailComponent 		  
		];
