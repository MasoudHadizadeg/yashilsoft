			
		import { Component, OnInit } from '@angular/core';
		import {ReportStoreDetailComponent} from './report-store-detail.component';
		@Component({
		  selector: 'app-report-store-list',
		  templateUrl: './report-store-list.component.html'
		})
		export class ReportStoreListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'reportStore';
		  detailComponent = ReportStoreDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
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
					caption: 'کلید گزارش',
					dataField: 'reportKey'
					});
							this.columns.push({ 
					caption: 'طراحی',
					dataField: 'designString'
					});
							this.columns.push({ 
					caption: 'ماژول',
					dataField: 'moduleKey'
					});
							
				}
		}
