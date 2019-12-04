import {ResourceDetailComponent} from './resource/resource-detail.component';
import {UserDetailComponent} from './user/user-detail.component';
import {OrganizationDetailComponent} from './organization/organization-detail.component';
import {AppConfigDetailComponent} from './app-config/app-config-detail.component';
import {AppActionDetailComponent} from './app-action/app-action-detail.component';
import {ResourceAppActionDetailComponent} from './resource-app-action/resource-app-action-detail.component';
import {RoleResourceActionDetailComponent} from './role-resource-action/role-resource-action-detail.component';
import {MenuDetailComponent} from './menu/menu-detail.component';
import {ApplicationDetailComponent} from './application/application-detail.component';
import {UserDashboardDetailComponent} from './user-dashboard/user-dashboard-detail.component';
import {RoleDashboardDetailComponent} from './role-dashboard/role-dashboard-detail.component';
import {DashboardDetailComponent} from './dashboard/dashboard-detail.component';
import {AccessLevelDetailComponent} from './access-level/access-level-detail.component';
import {RoleDetailComponent} from './role/role-detail.component';
import {UserRoleDetailComponent} from './user-role/user-role-detail.component';
import {Provider} from '@angular/core';

export const ENTRYCOMPONENTS: Provider[] = [
  ResourceDetailComponent,
  UserDetailComponent,
  OrganizationDetailComponent,
  AppConfigDetailComponent,
  AppActionDetailComponent,
  ResourceAppActionDetailComponent,
  RoleResourceActionDetailComponent,
  MenuDetailComponent,
  ApplicationDetailComponent,
  UserDashboardDetailComponent,
  RoleDashboardDetailComponent,
  DashboardDetailComponent,
  AccessLevelDetailComponent,
  RoleDetailComponent,
  UserRoleDetailComponent
];
