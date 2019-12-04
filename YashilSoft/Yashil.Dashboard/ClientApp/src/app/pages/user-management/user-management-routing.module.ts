import {DashboardListComponent} from './dashboard/dashboard-list.component';
import {RouterModule, Routes} from '@angular/router';
import {AccessLevelListComponent} from './access-level/access-level-list.component';
import {RoleListComponent} from './role/role-list.component';
import {NgModule} from '@angular/core';
import {ResourceListComponent} from './resource/resource-list.component';
import {AuthGuard} from '../../shared/_guards';
import {UserDashboardListComponent} from './user-dashboard/user-dashboard-list.component';
import {MenuListComponent} from './menu/menu-list.component';
import {RoleDashboardListComponent} from './role-dashboard/role-dashboard-list.component';
import {UserRoleListComponent} from './user-role/user-role-list.component';
import {AppActionListComponent} from './app-action/app-action-list.component';
import {ResourceAppActionListComponent} from './resource-app-action/resource-app-action-list.component';
import {AppConfigListComponent} from './app-config/app-config-list.component';
import {RoleResourceActionListComponent} from './role-resource-action/role-resource-action-list.component';
import {UserListComponent} from './user/user-list.component';
import {ApplicationListComponent} from './application/application-list.component';
import {OrganizationListComponent} from './organization/organization-list.component';

const routes: Routes = [
  {path: 'resources', component: ResourceListComponent, canActivate: [AuthGuard]},
  {path: 'users', component: UserListComponent, canActivate: [AuthGuard]},
  {path: 'organizations', component: OrganizationListComponent, canActivate: [AuthGuard]},
  {path: 'appConfigs', component: AppConfigListComponent, canActivate: [AuthGuard]},
  {path: 'appActions', component: AppActionListComponent, canActivate: [AuthGuard]},
  {path: 'resourceAppActions', component: ResourceAppActionListComponent, canActivate: [AuthGuard]},
  {path: 'roleResourceActions', component: RoleResourceActionListComponent, canActivate: [AuthGuard]},
  {path: 'menus', component: MenuListComponent, canActivate: [AuthGuard]},
  {path: 'applications', component: ApplicationListComponent, canActivate: [AuthGuard]},
  {path: 'userDashboards', component: UserDashboardListComponent, canActivate: [AuthGuard]},
  {path: 'roleDashboards', component: RoleDashboardListComponent, canActivate: [AuthGuard]},
  {path: 'dashboards', component: DashboardListComponent, canActivate: [AuthGuard]},
  {path: 'accessLevels', component: AccessLevelListComponent, canActivate: [AuthGuard]},
  {path: 'roles', component: RoleListComponent, canActivate: [AuthGuard]},
  {path: 'userRoles', component: UserRoleListComponent, canActivate: [AuthGuard]}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
  }
)
export class UserManagementRoutingModule {
}
