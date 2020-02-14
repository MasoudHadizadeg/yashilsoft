import {YashilDataProviderDetailComponent} from './yashil-data-provider/yashil-data-provider-detail.component';
import {YashilDataProviderListComponent} from './yashil-data-provider/yashil-data-provider-list.component';
import {YashilConnectionStringDetailComponent} from './yashil-connection-string/yashil-connection-string-detail.component';
import {YashilConnectionStringListComponent} from './yashil-connection-string/yashil-connection-string-list.component';
import {AccessLevelDetailComponent} from './access-level/access-level-detail.component';
import {AccessLevelListComponent} from './access-level/access-level-list.component';
import {Provider} from '@angular/core';
import {AppEntityDetailComponent} from './app-entity/app-entity-detail.component';
import {AppEntityListComponent} from './app-entity/app-entity-list.component';

export const COMPONENTS: Provider[] = [

    YashilDataProviderListComponent,
    YashilDataProviderDetailComponent,
    YashilConnectionStringListComponent,
    YashilConnectionStringDetailComponent,
    AccessLevelListComponent,
    AccessLevelDetailComponent,
    AppEntityDetailComponent,
    AppEntityListComponent
];
