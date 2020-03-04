			
		import { Component, OnInit } from '@angular/core';
		import {CommonBaseTypeDetailComponent} from './common-base-type-detail.component';
			
		

		@Component({
		  selector: 'app-common-base-type-list',
		  templateUrl: './common-base-type-list.component.html'
		})
		export class CommonBaseTypeListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'commonBaseType';
		  detailComponent = CommonBaseTypeDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'عنوان یکتای ستون',
					dataField: 'keyName'
					});
							this.columns.push({ 
					caption: 'TreeBased',
					dataField: 'treeBased'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
