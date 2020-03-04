			
		import { Component, OnInit } from '@angular/core';
		import {CommonBaseDataDetailComponent} from './common-base-data-detail.component';
			
		

		@Component({
		  selector: 'app-common-base-data-list',
		  templateUrl: './common-base-data-list.component.html'
		})
		export class CommonBaseDataListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'commonBaseData';
		  detailComponent = CommonBaseDataDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'ParentId',
					dataField: 'parentTitle'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'مقدار',
					dataField: 'value'
					});
							this.columns.push({ 
					caption: 'نوع اطلاعات پايه',
					dataField: 'commonBaseTypeTitle'
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
