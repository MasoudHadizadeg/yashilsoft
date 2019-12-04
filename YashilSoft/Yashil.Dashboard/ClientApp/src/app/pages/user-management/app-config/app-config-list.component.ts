			
		import { Component, OnInit } from '@angular/core';
		import {AppConfigDetailComponent} from './app-config-detail.component';
		@Component({
		  selector: 'app-app-config-list',
		  templateUrl: './app-config-list.component.html'
		})
		export class AppConfigListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'appConfig';
		  detailComponent = AppConfigDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'keyTitle'
					});
							this.columns.push({ 
					caption: 'مقدار',
					dataField: 'value'
					});
							this.columns.push({ 
					caption: 'توضیحات',
					dataField: 'description'
					});
							
				}
		}
