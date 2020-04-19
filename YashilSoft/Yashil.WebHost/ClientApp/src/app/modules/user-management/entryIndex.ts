import {ResourceDetailComponent} from './resource/resource-detail.component';

import {ApplicationDetailComponent} from './application/application-detail.component';

import {AppActionDetailComponent} from './app-action/app-action-detail.component';

import {OrganizationDetailComponent} from './organization/organization-detail.component';

import {ResourceAppActionDetailComponent} from './resource-app-action/resource-app-action-detail.component';

import {RoleResourceActionDetailComponent} from './role-resource-action/role-resource-action-detail.component';

import {RoleDetailComponent} from './role/role-detail.component';

import {AppConfigDetailComponent} from './app-config/app-config-detail.component';

import {UserDetailComponent} from './user/user-detail.component';

import {MenuDetailComponent} from './menu/menu-detail.component';

import {UserRoleDetailComponent} from './user-role/user-role-detail.component';

import {PostDetailComponent} from './post/post-detail.component';

import {PersonDetailComponent} from './person/person-detail.component';
import {Provider} from '@angular/core';
import {JobDetailComponent} from './job/job-detail.component';

export const ENTRYCOMPONENTS: Provider[] = [
    JobDetailComponent,
    ResourceDetailComponent,
    ApplicationDetailComponent,
    AppActionDetailComponent,
    OrganizationDetailComponent,
    ResourceAppActionDetailComponent,
    RoleResourceActionDetailComponent,
    RoleDetailComponent,
    AppConfigDetailComponent,
    UserDetailComponent,
    MenuDetailComponent,
    UserRoleDetailComponent,
    PostDetailComponent,
    PersonDetailComponent
];
