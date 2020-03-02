

import {Routes} from '@angular/router';
				import {CityDetailComponent} from './city/city-detail.component';
				import {CityListComponent} from './city/city-list.component';
								import {AppEntityDetailComponent} from './app-entity/app-entity-detail.component';
				import {AppEntityListComponent} from './app-entity/app-entity-list.component';
								import {CommonBaseDataDetailComponent} from './common-base-data/common-base-data-detail.component';
				import {CommonBaseDataListComponent} from './common-base-data/common-base-data-list.component';
								import {AccessLevelDetailComponent} from './access-level/access-level-detail.component';
				import {AccessLevelListComponent} from './access-level/access-level-list.component';
								import {YashilDataProviderDetailComponent} from './yashil-data-provider/yashil-data-provider-detail.component';
				import {YashilDataProviderListComponent} from './yashil-data-provider/yashil-data-provider-list.component';
								import {CommonBaseTypeDetailComponent} from './common-base-type/common-base-type-detail.component';
				import {CommonBaseTypeListComponent} from './common-base-type/common-base-type-list.component';
								import {YashilConnectionStringDetailComponent} from './yashil-connection-string/yashil-connection-string-detail.component';
				import {YashilConnectionStringListComponent} from './yashil-connection-string/yashil-connection-string-list.component';
							import {Provider} from '@angular/core';
			 
				export const COMPONENTS:Provider[]=[
				 
			  CityListComponent,
		  CityDetailComponent ,		  
			  AppEntityListComponent,
		  AppEntityDetailComponent ,		  
			  CommonBaseDataListComponent,
		  CommonBaseDataDetailComponent ,		  
			  AccessLevelListComponent,
		  AccessLevelDetailComponent ,		  
			  YashilDataProviderListComponent,
		  YashilDataProviderDetailComponent ,		  
			  CommonBaseTypeListComponent,
		  CommonBaseTypeDetailComponent ,		  
			  YashilConnectionStringListComponent,
		  YashilConnectionStringDetailComponent 		  
		];
