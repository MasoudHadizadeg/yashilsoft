			
		import { Component, OnInit } from '@angular/core';
		import {AppEntityAttributeDetailComponent} from './app-entity-attribute-detail.component';
			
		

		@Component({
		  selector: 'app-app-entity-attribute-list',
		  templateUrl: './app-entity-attribute-list.component.html'
		})
		export class AppEntityAttributeListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'appEntityAttribute';
		  detailComponent = AppEntityAttributeDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'سیستمی',
					dataField: 'isSystemProp'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
