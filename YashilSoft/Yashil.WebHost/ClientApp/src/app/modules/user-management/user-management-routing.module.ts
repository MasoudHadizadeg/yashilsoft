import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {ResourceListComponent} from './resource/resource-list.component';
import {ApplicationListComponent} from './application/application-list.component';
import {AppActionListComponent} from './app-action/app-action-list.component';
import {OrganizationListComponent} from './organization/organization-list.component';
import {ResourceAppActionListComponent} from './resource-app-action/resource-app-action-list.component';
import {RoleResourceActionListComponent} from './role-resource-action/role-resource-action-list.component';
import {RoleListComponent} from './role/role-list.component';
import {AppConfigListComponent} from './app-config/app-config-list.component';
import {UserListComponent} from './user/user-list.component';
import {MenuListComponent} from './menu/menu-list.component';
import {UserRoleListComponent} from './user-role/user-role-list.component';
import {PostListComponent} from './post/post-list.component';
import {PersonListComponent} from './person/person-list.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
    {path: 'resources', component: ResourceListComponent, canActivate: [AuthGuard]},
    {path: 'applications', component: ApplicationListComponent, canActivate: [AuthGuard]},
    {path: 'appActions', component: AppActionListComponent, canActivate: [AuthGuard]},
    {path: 'organizations', component: OrganizationListComponent, canActivate: [AuthGuard]},
    {path: 'resourceAppActions', component: ResourceAppActionListComponent, canActivate: [AuthGuard]},
    {path: 'roleResourceActions', component: RoleResourceActionListComponent, canActivate: [AuthGuard]},
    {path: 'roles', component: RoleListComponent, canActivate: [AuthGuard]},
    {path: 'appConfigs', component: AppConfigListComponent, canActivate: [AuthGuard]},
    {path: 'users', component: UserListComponent, canActivate: [AuthGuard]},
    {path: 'menus', component: MenuListComponent, canActivate: [AuthGuard]},
    {path: 'userRoles', component: UserRoleListComponent, canActivate: [AuthGuard]},
    {path: 'posts', component: PostListComponent, canActivate: [AuthGuard]},
    {path: 'persons', component: PersonListComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class UserManagementRoutingModule {

}
