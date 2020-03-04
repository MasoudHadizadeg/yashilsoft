			
		import { Component, OnInit } from '@angular/core';
		import {AppEntityAttributeValueDetailComponent} from './app-entity-attribute-value-detail.component';
			
		

		@Component({
		  selector: 'app-app-entity-attribute-value-list',
		  templateUrl: './app-entity-attribute-value-list.component.html'
		})
		export class AppEntityAttributeValueListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'appEntityAttributeValue';
		  detailComponent = AppEntityAttributeValueDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'ویژگی موجودیت',
					dataField: 'appEntityAttributeMappingTitle'
					});
							this.columns.push({ 
					caption: 'رکورد',
					dataField: 'objectId'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
