import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
import {AppEntityListComponent} from './app-entity/app-entity-list.component';
import {AccessLevelListComponent} from './access-level/access-level-list.component';
import {YashilDataProviderListComponent} from './yashil-data-provider/yashil-data-provider-list.component';
import {YashilConnectionStringListComponent} from './yashil-connection-string/yashil-connection-string-list.component';
import {FullLayoutSplitComponent} from '../../layouts/fullsplit/full-layout-split.component';
import {NgModule} from '@angular/core';

const routes: Routes = [
    {path: 'appEntitys', component: AppEntityListComponent, canActivate: [AuthGuard]},
    {path: 'accessLevels', component: AccessLevelListComponent, canActivate: [AuthGuard]},
    {path: 'yashilDataProviders', component: YashilDataProviderListComponent, canActivate: [AuthGuard]},
    {path: 'yashilConnectionStrings', component: YashilConnectionStringListComponent, canActivate: [AuthGuard]}
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class BaseInfoRoutingModule {

}
