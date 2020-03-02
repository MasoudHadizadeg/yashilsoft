			
		import { Component, OnInit } from '@angular/core';
		import {CoursesPlanningStudentDetailComponent} from './courses-planning-student-detail.component';
			
		

		@Component({
		  selector: 'app-courses-planning-student-list',
		  templateUrl: './courses-planning-student-list.component.html'
		})
		export class CoursesPlanningStudentListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'coursesPlanningStudent';
		  detailComponent = CoursesPlanningStudentDetailComponent; 		  constructor() {
							this.columns.push({ 
					caption: 'کد',
					dataField: 'code'
					});
							this.columns.push({ 
					caption: 'دوره',
					dataField: 'coursesPlanningTitle'
					});
							this.columns.push({ 
					caption: 'دانشجو',
					dataField: 'personTitle'
					});
							this.columns.push({ 
					caption: 'نمره',
					dataField: 'score'
					});
							this.columns.push({ 
					caption: 'سطح دسترسی',
					dataField: 'accessLevelTitle'
					});
							
				}
		}
