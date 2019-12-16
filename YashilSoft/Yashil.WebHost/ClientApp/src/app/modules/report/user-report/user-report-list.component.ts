			
		import { Component, OnInit } from '@angular/core';
		import {UserReportDetailComponent} from './user-report-detail.component';
		@Component({
		  selector: 'app-user-report-list',
		  templateUrl: './user-report-list.component.html'
		})
		export class UserReportListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'userReport';
		  detailComponent = UserReportDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'کاربر',
					dataField: 'userTitle'
					});
							this.columns.push({ 
					caption: 'گزارش',
					dataField: 'reportTitle'
					});
							
				}
		}
