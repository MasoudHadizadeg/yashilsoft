			
		import { Component, OnInit } from '@angular/core';
		import {DashboardDetailComponent} from './dashboard-detail.component';
		@Component({
		  selector: 'app-dashboard-list',
		  templateUrl: './dashboard-list.component.html'
		})
		export class DashboardListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'dashboard';
		  detailComponent = DashboardDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'توضیحات',
					dataField: 'description'
					});
							this.columns.push({ 
					caption: 'داشبورد',
					dataField: 'dashboardFile'
					});
							this.columns.push({ 
					caption: 'کلاس',
					dataField: 'cssClass'
					});
							this.columns.push({ 
					caption: 'تصویر',
					dataField: 'picture'
					});
							this.columns.push({ 
					caption: 'رنگ',
					dataField: 'color'
					});
							this.columns.push({ 
					caption: 'انیمیشن',
					dataField: 'animation'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
