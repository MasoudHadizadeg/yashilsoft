			
		import { Component, OnInit } from '@angular/core';
		import {EducationalCenterDetailComponent} from './educational-center-detail.component';
				import {EducationalCenterDetailTabBasedComponent} from './educational-center-detail-tab-based.component';
			
		

		@Component({
		  selector: 'app-educational-center-list',
		  templateUrl: './educational-center-list.component.html'
		})
		export class EducationalCenterListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'educationalCenter';
		  detailComponent =  EducationalCenterDetailTabBasedComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'آدرس',
					dataField: 'address'
					});
							this.columns.push({ 
					caption: 'نوع مجوز تاسیس',
					dataField: 'establishedLicenseType'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
