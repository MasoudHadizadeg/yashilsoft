import {YashilDataProviderDetailComponent} from './yashil-data-provider/yashil-data-provider-detail.component';
import {YashilConnectionStringDetailComponent} from './yashil-connection-string/yashil-connection-string-detail.component';
import {AccessLevelDetailComponent} from './access-level/access-level-detail.component';
import {Provider} from '@angular/core';
import {AppEntityDetailComponent} from './app-entity/app-entity-detail.component';

export const ENTRYCOMPONENTS: Provider[] = [
    YashilDataProviderDetailComponent,
    YashilConnectionStringDetailComponent,
    AccessLevelDetailComponent,
    AppEntityDetailComponent
];
