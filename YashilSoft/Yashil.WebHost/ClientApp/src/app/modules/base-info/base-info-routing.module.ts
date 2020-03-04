

import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../../shared/_guards';
				import {AppEntityListComponent} from './app-entity/app-entity-list.component';
								import {AccessLevelListComponent} from './access-level/access-level-list.component';
								import {YashilDataProviderListComponent} from './yashil-data-provider/yashil-data-provider-list.component';
								import {YashilConnectionStringListComponent} from './yashil-connection-string/yashil-connection-string-list.component';
								import {CityListComponent} from './city/city-list.component';
								import {CommonBaseDataListComponent} from './common-base-data/common-base-data-list.component';
								import {CommonBaseTypeListComponent} from './common-base-type/common-base-type-list.component';
								import {AppEntityAttributeListComponent} from './app-entity-attribute/app-entity-attribute-list.component';
								import {AppEntityAttributeMappingListComponent} from './app-entity-attribute-mapping/app-entity-attribute-mapping-list.component';
								import {AppEntityAttributeValueListComponent} from './app-entity-attribute-value/app-entity-attribute-value-list.component';
				import {FullLayoutSplitComponent} from '../../layouts/fullsplit/full-layout-split.component';
import {NgModule} from '@angular/core';
const routes: Routes = [    
					{path: 'appEntitys', component: AppEntityListComponent, canActivate: [AuthGuard]},		  
					{path: 'accessLevels', component: AccessLevelListComponent, canActivate: [AuthGuard]},		  
					{path: 'yashilDataProviders', component: YashilDataProviderListComponent, canActivate: [AuthGuard]},		  
					{path: 'yashilConnectionStrings', component: YashilConnectionStringListComponent, canActivate: [AuthGuard]},		  
					{path: 'citys', component: CityListComponent, canActivate: [AuthGuard]},		  
					{path: 'commonBaseDatas', component: CommonBaseDataListComponent, canActivate: [AuthGuard]},		  
					{path: 'commonBaseTypes', component: CommonBaseTypeListComponent, canActivate: [AuthGuard]},		  
					{path: 'appEntityAttributes', component: AppEntityAttributeListComponent, canActivate: [AuthGuard]},		  
					{path: 'appEntityAttributeMappings', component: AppEntityAttributeMappingListComponent, canActivate: [AuthGuard]},		  
					{path: 'appEntityAttributeValues', component: AppEntityAttributeValueListComponent, canActivate: [AuthGuard]}		  
	];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule],
    }
)
export class BaseInfoRoutingModule {

}
