			
		import { Component, OnInit } from '@angular/core';
		import {RepresentationPersonDetailComponent} from './representation-person-detail.component';
			
		

		@Component({
		  selector: 'app-representation-person-list',
		  templateUrl: './representation-person-list.component.html'
		})
		export class RepresentationPersonListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'representationPerson';
		  detailComponent = RepresentationPersonDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'نمایندگی',
					dataField: 'representationTitle'
					});
							this.columns.push({ 
					caption: 'شخص',
					dataField: 'personTitle'
					});
							this.columns.push({ 
					caption: 'سمت',
					dataField: 'postTitle'
					});
							this.columns.push({ 
					caption: 'نوع همکاری مدرسین',
					dataField: 'cooperationTypeTitle'
					});
							this.columns.push({ 
					caption: 'تاریخ جذب',
					dataField: 'fromDate'
					});
							this.columns.push({ 
					caption: 'تاریخ رهایی',
					dataField: 'toDate'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
