			
		import { Component, OnInit } from '@angular/core';
		import {JobDetailComponent} from './job-detail.component';
			
		

		@Component({
		  selector: 'app-job-list',
		  templateUrl: './job-list.component.html'
		})
		export class JobListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'job';
		  detailComponent = JobDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'عنوان',
					dataField: 'title'
					});
							
				}
		}
