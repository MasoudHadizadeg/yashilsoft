			
		import { Component, OnInit } from '@angular/core';
		import {YashilConnectionStringDetailComponent} from './yashil-connection-string-detail.component';
		@Component({
		  selector: 'app-yashil-connection-string-list',
		  templateUrl: './yashil-connection-string-list.component.html'
		})
		export class YashilConnectionStringListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'yashilConnectionString';
		  detailComponent = YashilConnectionStringDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'name'
					});
							this.columns.push({ 
					caption: 'تامین کننده داده',
					dataField: 'dataProviderTitle'
					});
							this.columns.push({ 
					caption: 'رشته اتصال',
					dataField: 'connectionString'
					});
							this.columns.push({ 
					caption: 'فعال بودن',
					dataField: 'isActive'
					});
							
				}
		}
