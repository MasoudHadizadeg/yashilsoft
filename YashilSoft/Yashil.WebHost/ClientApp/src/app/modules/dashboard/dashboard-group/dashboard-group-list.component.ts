			
		import { Component, OnInit } from '@angular/core';
		import {DashboardGroupDetailComponent} from './dashboard-group-detail.component';
		@Component({
		  selector: 'app-dashboard-group-list',
		  templateUrl: './dashboard-group-list.component.html'
		})
		export class DashboardGroupListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'dashboardGroup';
		  detailComponent = DashboardGroupDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							
				}
		}
