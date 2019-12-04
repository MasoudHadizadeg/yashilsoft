			
		import { Component, OnInit } from '@angular/core';
		import {ReportGroupDetailComponent} from './report-group-detail.component';
		@Component({
		  selector: 'app-report-group-list',
		  templateUrl: './report-group-list.component.html'
		})
		export class ReportGroupListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'reportGroup';
		  detailComponent = ReportGroupDetailComponent;
		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							
				}
		}
