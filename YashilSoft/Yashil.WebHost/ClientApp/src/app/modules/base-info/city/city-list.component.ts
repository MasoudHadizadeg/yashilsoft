			
		import { Component, OnInit } from '@angular/core';
		import {CityDetailComponent} from './city-detail.component';
			
		

		@Component({
		  selector: 'app-city-list',
		  templateUrl: './city-list.component.html'
		})
		export class CityListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'city';
		  detailComponent = CityDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'ParentId',
					dataField: 'parentTitle'
					});
							this.columns.push({ 
					caption: 'عرض جغرافیایی',
					dataField: 'latitude'
					});
							this.columns.push({ 
					caption: 'طول جغرافیایی',
					dataField: 'longitude'
					});
							this.columns.push({ 
					caption: 'تقسیم بندی سفارشی',
					dataField: 'customCategoryTitle'
					});
							this.columns.push({ 
					caption: 'تقسیمات کشوری',
					dataField: 'countryDivisionTypeTitle'
					});
							this.columns.push({ 
					caption: 'مرکز استان',
					dataField: 'provinceCenter'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							
				}
		}
