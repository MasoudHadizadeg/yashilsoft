

import {Routes} from '@angular/router';
				
				import {AppEntityDetailComponent} from './app-entity/app-entity-detail.component';
				import {AppEntityListComponent} from './app-entity/app-entity-list.component';
								
				import {AccessLevelDetailComponent} from './access-level/access-level-detail.component';
				import {AccessLevelListComponent} from './access-level/access-level-list.component';
								
				import {YashilDataProviderDetailComponent} from './yashil-data-provider/yashil-data-provider-detail.component';
				import {YashilDataProviderListComponent} from './yashil-data-provider/yashil-data-provider-list.component';
								
				import {YashilConnectionStringDetailComponent} from './yashil-connection-string/yashil-connection-string-detail.component';
				import {YashilConnectionStringListComponent} from './yashil-connection-string/yashil-connection-string-list.component';
								
				import {CityDetailComponent} from './city/city-detail.component';
				import {CityListComponent} from './city/city-list.component';
								
				import {CommonBaseDataDetailComponent} from './common-base-data/common-base-data-detail.component';
				import {CommonBaseDataListComponent} from './common-base-data/common-base-data-list.component';
								
				import {CommonBaseTypeDetailComponent} from './common-base-type/common-base-type-detail.component';
				import {CommonBaseTypeListComponent} from './common-base-type/common-base-type-list.component';
								
				import {AppEntityAttributeDetailComponent} from './app-entity-attribute/app-entity-attribute-detail.component';
				import {AppEntityAttributeListComponent} from './app-entity-attribute/app-entity-attribute-list.component';
								
				import {AppEntityAttributeMappingDetailComponent} from './app-entity-attribute-mapping/app-entity-attribute-mapping-detail.component';
				import {AppEntityAttributeMappingListComponent} from './app-entity-attribute-mapping/app-entity-attribute-mapping-list.component';
								
				import {AppEntityAttributeValueDetailComponent} from './app-entity-attribute-value/app-entity-attribute-value-detail.component';
				import {AppEntityAttributeValueListComponent} from './app-entity-attribute-value/app-entity-attribute-value-list.component';
							import {Provider} from '@angular/core';
			export const COMPONENTS:Provider[]=[
				 
			  AppEntityListComponent,
		
		  AppEntityDetailComponent ,		  
			  AccessLevelListComponent,
		
		  AccessLevelDetailComponent ,		  
			  YashilDataProviderListComponent,
		
		  YashilDataProviderDetailComponent ,		  
			  YashilConnectionStringListComponent,
		
		  YashilConnectionStringDetailComponent ,		  
			  CityListComponent,
		
		  CityDetailComponent ,		  
			  CommonBaseDataListComponent,
		
		  CommonBaseDataDetailComponent ,		  
			  CommonBaseTypeListComponent,
		
		  CommonBaseTypeDetailComponent ,		  
			  AppEntityAttributeListComponent,
		
		  AppEntityAttributeDetailComponent ,		  
			  AppEntityAttributeMappingListComponent,
		
		  AppEntityAttributeMappingDetailComponent ,		  
			  AppEntityAttributeValueListComponent,
		
		  AppEntityAttributeValueDetailComponent 		  
		];
