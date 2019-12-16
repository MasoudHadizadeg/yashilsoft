			
		import { Component, OnInit } from '@angular/core';
		import {AppActionDetailComponent} from './app-action-detail.component';
		@Component({
		  selector: 'app-app-action-list',
		  templateUrl: './app-action-list.component.html'
		})
		export class AppActionListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'appAction';
		  detailComponent = AppActionDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							this.columns.push({ 
					caption: 'SystemAction',
					dataField: 'systemAction'
					});
							
				}
		}
