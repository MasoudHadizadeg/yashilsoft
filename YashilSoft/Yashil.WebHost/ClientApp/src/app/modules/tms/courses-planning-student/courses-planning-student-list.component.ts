			
		import { Component, OnInit } from '@angular/core';
		import {CoursesPlanningStudentDetailComponent} from './courses-planning-student-detail.component';
				import {CoursesPlanningStudentDetailTabBasedComponent} from './courses-planning-student-detail-tab-based.component';
			
		

		@Component({
		  selector: 'app-courses-planning-student-list',
		  templateUrl: './courses-planning-student-list.component.html'
		})
		export class CoursesPlanningStudentListComponent {
		  selectedItemId: number;
		  columns: any[] = [];
		  entityName = 'coursesPlanningStudent';
		  detailComponent =  CoursesPlanningStudentDetailTabBasedComponent; 		  constructor() {
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
							
				}
		}
