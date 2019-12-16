			
		import { Component, OnInit } from '@angular/core';
		import {UserDashboardDetailComponent} from './user-dashboard-detail.component';
		@Component({
		  selector: 'app-user-dashboard-list',
		  templateUrl: './user-dashboard-list.component.html'
		})
		export class UserDashboardListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'userDashboard';
		  detailComponent = UserDashboardDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'کاربر',
					dataField: 'userTitle'
					});
							this.columns.push({ 
					caption: 'داشبورد',
					dataField: 'dashboardTitle'
					});
							
				}
		}
