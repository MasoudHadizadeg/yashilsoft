			
		import { Component, OnInit } from '@angular/core';
		import {ResourceAppActionDetailComponent} from './resource-app-action-detail.component';
		@Component({
		  selector: 'app-resource-app-action-list',
		  templateUrl: './resource-app-action-list.component.html'
		})
		export class ResourceAppActionListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'resourceAppAction';
		  detailComponent = ResourceAppActionDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عملیات',
					dataField: 'appActionTitle'
					});
							this.columns.push({ 
					caption: 'منبع',
					dataField: 'resourceTitle'
					});
							
				}
		}
