			
		import { Component, OnInit } from '@angular/core';
		import {RepresentationDetailComponent} from './representation-detail.component';
				import {RepresentationDetailTabBasedComponent} from './representation-detail-tab-based.component';
			
		

		@Component({
		  selector: 'app-representation-list',
		  templateUrl: './representation-list.component.html'
		})
		export class RepresentationListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'representation';
		  detailComponent =  RepresentationDetailTabBasedComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'مرکز آموشي',
					dataField: 'educationalCenterTitle'
					});
							this.columns.push({ 
					caption: 'شهر',
					dataField: 'cityTitle'
					});
							this.columns.push({ 
					caption: 'رایانامه (Email)',
					dataField: 'email'
					});
							this.columns.push({ 
					caption: 'شماره تلفن',
					dataField: 'telephone'
					});
							this.columns.push({ 
					caption: 'دور نگار',
					dataField: 'faxNumber'
					});
							this.columns.push({ 
					caption: 'شماره مجوز',
					dataField: 'licenseNumber'
					});
							this.columns.push({ 
					caption: 'نوع مجوز تاسیس',
					dataField: 'licenseTypeTitle'
					});
							this.columns.push({ 
					caption: 'نوع مالکیت',
					dataField: 'ownershipType'
					});
							this.columns.push({ 
					caption: 'نوع مجوز تاسیس',
					dataField: 'establishedLicenseType'
					});
							this.columns.push({ 
					caption: 'متراژ',
					dataField: 'area'
					});
							this.columns.push({ 
					caption: 'نوع مالکیت',
					dataField: 'ownershipTypeTitle'
					});
							this.columns.push({ 
					caption: 'کد پستی',
					dataField: 'postalCode'
					});
							this.columns.push({ 
					caption: 'آدرس',
					dataField: 'address'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
